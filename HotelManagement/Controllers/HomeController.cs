using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagement.Controllers
{


    [Authorize (Roles = "Admin, Receptionist")]
    public class HomeController : Controller
    {
        IRoomService roomService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IRoomService service)
        {
            _logger = logger;
            roomService = service;
        }

        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.listCoupleRooms = roomService.GetCoupleRooms();
            model.listAllRooms = roomService.GetAllRooms();
            model.listviews = model.listAllRooms.GroupBy(a => a.RoomView).Select(a => a.First()).ToList();
            model.listBigRooms = model.listAllRooms.Where(a => a.NoOfBeds >= 4).Take(4).ToList();
            return View(model);
        }
        public IActionResult UnCheckedRoomsList()
        {
            AvailableRoomListModel model = new AvailableRoomListModel();
            model.listAllRooms = roomService.GetAllRooms();
            model.listviews = model.listAllRooms.GroupBy(a => a.RoomView).Select(a => a.First()).ToList();
            return View(model);
        }
        public IActionResult AvailableRoomsList(CheckRoomAvailability? checkRoom)
        {
            if (checkRoom.ArrivingDate < DateTime.Now)
            {
                ModelState.AddModelError("ArrivingDate", "Please enter valid date");
                return RedirectToAction(nameof(Index));
            }
            if (checkRoom.LeavingDate <= DateTime.Now)
            {
                ModelState.AddModelError("LeavingDate", "Please enter valid date");
                return RedirectToAction(nameof(Index));
            }
            if(!ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            AvailableRoomListModel model = new AvailableRoomListModel();
            var allRooms = roomService.GetAllRooms();
            model.listAllRooms = allRooms.Where(a => a.NoOfBeds == checkRoom.BedsNumber).ToList();
            var CheckedRooms = roomService.GetAvailableCheckedRooms(checkRoom.ArrivingDate, checkRoom.BedsNumber);
            var Additionrooms = CheckedRooms.Select(r => new TbRooms
            {
                RoomId = r.RoomId,
                EmployeeId = r.EmployeeId,
                ViewId = r.ViewId,
                RoomView = r.RoomView,
                RoomCleaner = r.RoomCleaner,
                RoomFloor = r.RoomFloor,
                RoomNo = r.RoomNo,
                ImageName = r.ImageName,
                RoomPrice = r.RoomPrice,
                NoOfPersons = r.NoOfPersons,
                NoOfBeds = r.NoOfBeds,
                ShortDescription = r.ShortDescription,
                LongDescription = r.LongDescription,
                Status = r.Status,
            });
            model.listAllRooms.AddRange(Additionrooms);
            model.listviews = model.listAllRooms.GroupBy(a => a.RoomView).Select(a => a.First()).ToList();

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
