using Bl;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class GuestsController : Controller
    {
        IRoomService roomService;
        public GuestsController(IRoomService service)
        {
            roomService = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GuestRoomPass()
        {
            return View(new RoomPasswordVwModel());
        }

        [HttpPost]
        public IActionResult GuestServices(RoomPasswordVwModel model)
        {
            if (model.RoomPassword == null)
                return NotFound();

            var findroom = roomService.GetByPassword(model.RoomPassword);

            if (!findroom)
                return NotFound();



            return View(model);
        }


        public IActionResult GuestServices(string roompass)
        {


            var findroom = roomService.GetByPassword(roompass);

            if (!findroom)
                return NotFound();

            RoomPasswordVwModel model = new RoomPasswordVwModel();
            model.RoomPassword = roompass;

            return View(model);
        }
    }
}
