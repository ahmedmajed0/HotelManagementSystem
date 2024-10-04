using Bl;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class ReservationsController : Controller
    {
        IReservationService reservationService;
        IMeelService meelService;
        IRoomService roomService;
        public ReservationsController(IReservationService service, IMeelService service2, IRoomService room)
        {
            reservationService = service;
            meelService = service2;
            roomService = room;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReservNow(int Id)
        {
            ReservationPageModel reservationPageModel = new ReservationPageModel();
            reservationPageModel.RoomId = Id;

            var room = roomService.GetById(Id);
            reservationPageModel.RoomNo = room.RoomNo;

            ViewBag.Meels = meelService.GetAll();
            ViewBag.RoomPrice = room.RoomPrice;

            return View(reservationPageModel);
        }


        public IActionResult ViewReservationData()
        {
            var model = reservationService.GetAfterReservationData();
            var diff = model.LeavingDate.Subtract(model.ArrivingDate);

            var night = (int)diff.TotalDays;

            ViewBag.Total = night * model.RoomPrice;
            return View(model);
        }


        [HttpPost]
        public IActionResult ReservNow(ReservationPageModel OreservationPage)
        {

            if (OreservationPage.Reservation.ArrivingDate < DateTime.Today)
            {
                ViewBag.ArrivingError = "Please Enter Valid Date";
                ViewBag.Meels = meelService.GetAll();
                return View(OreservationPage);
            }

            if (OreservationPage.Reservation.LeavingDate < DateTime.Today)
            {
                ViewBag.LeavingError = "Please Enter Valid Date";
                ViewBag.Meels = meelService.GetAll();
                return View(OreservationPage);

            }

            if (OreservationPage.Reservation.LeavingDate <= OreservationPage.Reservation.ArrivingDate)
            {
                ViewBag.LeavingError = "This date is equal or less than arriving date, select diffrent date";
                ViewBag.Meels = meelService.GetAll();
                return View(OreservationPage);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    OreservationPage.Reservation.Status = "Exist";
                    reservationService.AddRoomReservation(OreservationPage.Reservation,
                    OreservationPage.Client,
                    OreservationPage.RoomId);

                    return RedirectToAction(nameof(ViewReservationData));

                }

                ViewBag.Meels = meelService.GetAll();
                return View(OreservationPage);
            }
        }
    }
}
