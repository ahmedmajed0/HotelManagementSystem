using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl;
using Domains;
using HotelManagement.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportsController : Controller
    {
        IReportService reportService;
        ICleanService cleanService;
        public ReportsController(IReportService report, ICleanService clean)
        {
            reportService = report;
            cleanService = clean;
        }
        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "BasicUser")]
        public IActionResult GuestsReport()
        {
            return View(reportService.GuestReport());
        }

        [Authorize(Roles = "BasicUser")]
        public IActionResult MeelsReport()
        {
            MeelsReportModel model = new MeelsReportModel();

            model.meelNumber = reportService.MeelNoReport();
            model.RoomMeels = reportService.RoomMeelsReport();

            return View(model);
        }

        [Authorize(Roles = "BasicUser")]
        public IActionResult ComingReservations() 
        {
            ReservationsReportModel model = new ReservationsReportModel();
            List<VwRoomReservation> listreservationts = reportService.AllReservationsReport();
            model.Reservations = listreservationts.Where(a => a.ArrivingDate.Date > DateTime.Today).ToList();
            model.Total = model.Reservations.Sum(a => a.TotalPrice);

            return View(model);
        }

        [Authorize(Roles = "BasicUser")]
        public IActionResult CheckInToday()
        {
            ReservationsReportModel model = new ReservationsReportModel();
            List<VwRoomReservation> listreservationts = reportService.AllReservationsReport();
            model.Reservations = listreservationts.Where(a => a.ArrivingDate.Date == DateTime.Today).ToList();
            model.Total = model.Reservations.Sum(a => a.TotalPrice);
            return View(model);
        }

        [Authorize(Roles = "BasicUser")]
        public IActionResult CheckOutToday()
        {
            ReservationsReportModel model = new ReservationsReportModel();
            List<VwRoomReservation> listreservationts = reportService.AllReservationsReport();
            model.Reservations = listreservationts.Where(a => a.LeavingDate.Date == DateTime.Today).ToList();
            model.Total = model.Reservations.Sum(a => a.TotalPrice);
            return View(model);
        }


        [Authorize(Roles = "BasicUser")]
        public IActionResult HouseKeepingReport()
        {
            return View(reportService.HouseKeepingReport());
        }

        [Authorize(Roles = "BasicUser")]
        public IActionResult DailyHouseKeepingReport()
        {
            return View(reportService.DailyHouseKeepingReport());
        }

        [Authorize(Roles = "BasicUser")]
        public IActionResult RequestsRoomServiceReport()
        {
            return View(cleanService.GetAllToday());
        }



        [Authorize(Roles = "Receptionist")]
        public IActionResult CheckedRooms()
        {

            return View(reportService.CheckedRooms());
        }


        [Authorize(Roles = "Receptionist")]
        public IActionResult AvailableRooms()
        {

            return View(reportService.AvailableRooms());
        }



        [Authorize(Roles = "Admin")]
        public IActionResult TodayImports()
        {
            return View(reportService.TodayImports());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult TodayExports()
        {
            return View(reportService.TodayExports());
        }
    }
}
