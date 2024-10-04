using Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bl
{
    public interface IReservationService 
    {
        int AddClient(TbClients Oclient);

        int AddResevation(TbReservations Oreservation, TbClients Oclient, int Id);

        bool EditResevation(TbReservations Oreservation);

        TbReservations GetById(int id);

        bool DoneResevation(TbReservations Oreservation);

        bool DeleteResevation(TbReservations Oreservation);
        int CheckedRoom(int Id);

        bool AvailableRoom(int Id);

        bool AddRoomReservation(TbReservations Oreservation, TbClients Oclient, int Id);


        VwAfterRoomReservation GetAfterReservationData();


        List<TbReservations> GetAllReservations();

        TbReservations GetReservationById(int Id);

        bool AddPayment(int resrvId, decimal total);
    }

    public class ClsReservations : IReservationService
    {
        HotelManegementContext ctx;
        IRoomService roomService;
        IMeelService meelService;
        public ClsReservations(HotelManegementContext context, IRoomService service, IMeelService meel)
        {
            ctx = context;
            roomService = service;
            meelService = meel;
        }

        
        public int AddClient(TbClients Oclient )
        {
            try
            {
                ctx.TbClients.Add(Oclient);
                ctx.SaveChanges();

                TbClients client = ctx.TbClients.OrderByDescending(a => a.ClientId).FirstOrDefault();
                return client.ClientId;
            }
            catch (Exception ex)
            {
                return -1;
            }
            
        }

        public int AddResevation(TbReservations Oreservation, TbClients Oclient, int Id)
        {
            try
            {
                if(Oreservation.MeelId != null)
                {
                    Oreservation.MeelPrice = meelService.GetPriceById((int)Oreservation.MeelId);
                }

                Oreservation.ClientId = AddClient(Oclient);

                var diffrence = Oreservation.LeavingDate.Subtract(Oreservation.ArrivingDate);


                Oreservation.Nights = (int)diffrence.TotalDays;  
                Oreservation.TotalPrice = (Oreservation.Nights) * roomService.GetRoomPriceById(Id) + Oreservation.MeelPrice - (int)Oreservation.Discount;
                Oreservation.RoomId = Id;

                ctx.TbReservations.Add(Oreservation);
                ctx.SaveChanges();

                

                TbReservations reservation = ctx.TbReservations.OrderByDescending(a => a.ReservationId).FirstOrDefault();
                return reservation.ReservationId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public bool AddRoomReservation(TbReservations Oreservation, TbClients Oclient , int Id)
        {
            try
            {
                TbRoomReservations OroomReservations = new TbRoomReservations();
                OroomReservations.ReservationId = AddResevation(Oreservation, Oclient, Id);
                OroomReservations.RoomId = CheckedRoom(Id);

                var room = ctx.TbRooms.Where(a => a.RoomId == Id).FirstOrDefault();
                room.RoomPassword = room.RoomNo.ToString() + Oclient.Phone;
                roomService.Edit(room);

                ctx.TbRoomReservations.Add(OroomReservations);
                ctx.SaveChanges();

                AddPayment((int)OroomReservations.ReservationId, Oreservation.TotalPrice);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditResevation(TbReservations Oreservation)
        {
            try
            {
                TbReservations realReservation = ctx.TbReservations.Where(a => a.ReservationId == Oreservation.ReservationId).FirstOrDefault();
                realReservation.AdultsNo = Oreservation.AdultsNo;
                realReservation.ChildNo = Oreservation.ChildNo;
                realReservation.ArrivingDate = Oreservation.ArrivingDate;
                realReservation.LeavingDate = Oreservation.LeavingDate;

                if (Oreservation.MeelId != null)
                {
                    realReservation.MeelPrice = meelService.GetPriceById((int)Oreservation.MeelId);
                    realReservation.MeelId = Oreservation.MeelId;
                }
                else
                {
                    realReservation.MeelPrice = 0;
                    realReservation.MeelId = null;
                }

                var diffrence = Oreservation.LeavingDate.Subtract(Oreservation.ArrivingDate);


                Oreservation.Nights = (int)diffrence.TotalDays;

                realReservation.Nights = Oreservation.Nights;

                var roomPrice = roomService.GetRoomPriceById(realReservation.RoomId);

                realReservation.TotalPrice = ((Oreservation.Nights) * roomPrice) + realReservation.MeelPrice -(int)Oreservation.Discount;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public int CheckedRoom(int Id)
        {
            TbRooms room = new TbRooms();
            room = ctx.TbRooms.Where(a => a.RoomId == Id).FirstOrDefault();
            room.Status = "Checked";
            roomService.Edit(room);
            return Id;
        }

        public bool AvailableRoom(int Id)
        {
            TbRooms room = new TbRooms();
            room = ctx.TbRooms.Where(a => a.RoomId == Id).FirstOrDefault();
            room.Status = "Available";
            room.RoomPassword = null;
            ctx.SaveChanges();
            return true;
        }

        public List<TbReservations> GetAllReservations()
        {
            List <TbReservations> listreservations = ctx.TbReservations.Where(a => a.Status == "Exist").OrderBy(a => a.LeavingDate).ToList();
            return listreservations;
        }

        public TbReservations GetReservationById(int Id)
        {
            return ctx.TbReservations.Where(a => a.ReservationId == Id).FirstOrDefault();
        }

        public bool DeleteResevation(TbReservations Oreservation)
        {
            try
            {
                TbRoomReservations OroomReservations = ctx.TbRoomReservations.Where(a => a.RoomId == Oreservation.RoomId &&
                a.ReservationId == Oreservation.ReservationId).FirstOrDefault();

                ctx.Remove<TbRoomReservations>(OroomReservations);
                ctx.SaveChanges();

                AvailableRoom(Oreservation.RoomId);

                TbClients Oclient = ctx.TbClients.Where(a => a.ClientId == Oreservation.ClientId).FirstOrDefault();
                ctx.Remove<TbClients>(Oclient);
                ctx.SaveChanges();

                ctx.Remove<TbReservations>(Oreservation);
                ctx.SaveChanges();



                var oPayment = ctx.TbPayments.Where(a => a.ReservationId == Oreservation.ReservationId).FirstOrDefault();
                ctx.Remove<TbPayments>(oPayment);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }




        public bool DoneResevation(TbReservations Oreservation)
        {
            try
            {

                Oreservation.Status = "Done";
                EditResevation(Oreservation);

                AvailableRoom(Oreservation.RoomId);


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool AddPayment(int resrvId, decimal total)
        {
            try
            {
                TbPayments oPayment = new TbPayments();
                oPayment.ReservationId = resrvId;
                oPayment.TotalPaidPrice = total;
                oPayment.PaymentDate = DateTime.Now;

                ctx.TbPayments.Add(oPayment);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TbReservations GetById(int id)
        {
            return ctx.TbReservations.Where(a => a.ReservationId == id).FirstOrDefault();
        }

        public VwAfterRoomReservation GetAfterReservationData()
        {
            return ctx.VwAfterRoomReservation.OrderByDescending(a => a.ReservationId).FirstOrDefault();
        }
    }
}
