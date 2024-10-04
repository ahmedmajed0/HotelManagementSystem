using Bl;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Receptionist")]
    public class ReservationsController : Controller
    {
        IReservationService reservationService;
        IMeelService meelService;
        IOrderService orderService;
        IRoomService roomService;
        public ReservationsController(IReservationService reservation, IMeelService meel, IOrderService order, IRoomService room)
        {
            reservationService = reservation;
            meelService = meel;
            orderService = order;
            roomService = room;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllReservations()
        {
            return View(reservationService.GetAllReservations());
        }

        public IActionResult Edit(int Id)
        {
            ViewBag.Meels = meelService.GetAll();
            return View(reservationService.GetReservationById(Id));
        }


        [HttpPost]
        public IActionResult Edit(TbReservations Oreservation)
        {
            TbReservations old = reservationService.GetReservationById(Oreservation.ReservationId);


            if (Oreservation.LeavingDate < DateTime.Today)
            {
                ViewBag.LeavingError = "Please Enter Valid Date";
                ViewBag.Meels = meelService.GetAll();

                return View(Oreservation);
            }
           if(Oreservation.ArrivingDate < old.ArrivingDate)
            {
                ViewBag.ArrivingError = "This is not The Old Date";
                ViewBag.Meels = meelService.GetAll();


                return View(Oreservation);
            }

            if (Oreservation.LeavingDate <= Oreservation.ArrivingDate)
            {
                ViewBag.LeavingError = "This date is equal or less than arriving date, select diffrent date";
                ViewBag.Meels = meelService.GetAll();


                return View(Oreservation);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    reservationService.EditResevation(Oreservation);


                    return RedirectToAction("AllReservations");

                }

                ViewBag.Meels = meelService.GetAll();
                return View(Oreservation);
            }
            
        }



        public IActionResult CheckOutReservation(int ReservationId)
        {
            CheckOutModel model = new CheckOutModel();

            var reservation = reservationService.GetById(ReservationId);
            model.RservationId = ReservationId;

            var room = roomService.GetById(reservation.RoomId);

            var lstvw = orderService.ClientFoodUnpaid(room.RoomNo);


            model.RoomNumber = room.RoomNo;
            model.lstFoodUnpaid = lstvw.Where(a => a.PaymentStatus == "Un paid").ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult CheckOutNow(CheckOutModel model)
        {
            var reservation = reservationService.GetById(model.RservationId);

            reservation.LeavingDate = DateTime.Today;
            reservationService.DoneResevation(reservation);

            orderService.DeleteOrder(model.clFoodId);

            return RedirectToAction("AllReservations");
        }


        public IActionResult DoneReservation(int Id)
        {
            TbReservations reservation = reservationService.GetReservationById(Id);
            
            reservationService.DoneResevation(reservation);

            return RedirectToAction("AllReservations");
        }

        public IActionResult Delete(int Id)
        {
            TbReservations reservation = reservationService.GetReservationById(Id);
            reservationService.DeleteResevation(reservation);
            return RedirectToAction("AllReservations");
        }
    }
}
