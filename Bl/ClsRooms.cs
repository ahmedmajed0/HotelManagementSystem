using Domains;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Bl
{
    public interface IRoomService 
    {
        List<TbRooms> GetAll();

        List<TbRooms> GetCoupleRooms();
        List<TbRooms> GetAllRooms();

        List<VwCheckingRoomAvailablity> GetAvailableCheckedRooms(DateTime arriving, int bedsNo);
        List<TbRooms> GetBigRooms();

        decimal GetRoomPriceById(int Id);

        List<TbRooms> GetRelatedRooms(int beds);

        TbRooms GetById(int Id);

        bool GetByPassword(string pass);

        TbRooms GetByRoomNo(int Id);
        bool Add(TbRooms oRoom);
        bool Edit(TbRooms oRoom);
        bool Delete(TbRooms oRoom);
    }

    public class ClsRooms: IRoomService
    {
        HotelManegementContext ctx;
        public ClsRooms(HotelManegementContext contex)
        {
            ctx = contex;
        }

        public bool Add(TbRooms oRoom)
        {
            try
            {
                ctx.Add<TbRooms>(oRoom);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public bool Delete(TbRooms oRoom)
        {
            try
            {
                ctx.Remove<TbRooms>(oRoom);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(TbRooms oRoom)
        {
            try
            {
                ctx.Entry(oRoom).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TbRooms> GetAll()
        {
            return ctx.TbRooms.ToList();
        }

        public List<TbRooms> GetCoupleRooms()
        {
            return ctx.TbRooms.Where(a => a.Status == "Available" && a.NoOfBeds == 1).ToList();
        }


        public List<TbRooms> GetAllRooms()
        {
            return ctx.TbRooms.Where(a => a.Status == "Available").ToList();
        }


        public List<VwCheckingRoomAvailablity> GetAvailableCheckedRooms(DateTime arriving, int bedsNo)
        {
            return ctx.VwCheckingRoomAvailablity.Where(a => a.LeavingDate < arriving && a.NoOfBeds == bedsNo).ToList();
        }


        public List<TbRooms> GetBigRooms()
        {
            return ctx.TbRooms.Where(a => a.Status == "Available" && a.NoOfBeds >= 4).ToList();
        }


        public TbRooms GetById(int Id)
        {
            return ctx.TbRooms.Where(a => a.RoomId == Id).FirstOrDefault();
        }


        public bool GetByPassword(string pass)
        {
            return ctx.TbRooms.Any(a => a.RoomPassword == pass);
        }

        

        public TbRooms GetByRoomNo(int RoomNo)
        {
            return ctx.TbRooms.Where(a => a.RoomNo == RoomNo).FirstOrDefault();
        }

        public List<TbRooms> GetRelatedRooms(int beds)
        {
            return GetAll().Where(a => a.NoOfBeds == beds).ToList();
        }

        public decimal GetRoomPriceById(int Id)
        {
            TbRooms Oroom = ctx.TbRooms.Where(a => a.RoomId == Id).FirstOrDefault();
            return Oroom.RoomPrice;
        }

        
    }
}
