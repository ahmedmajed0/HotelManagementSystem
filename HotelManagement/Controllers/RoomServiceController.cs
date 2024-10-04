using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl;
using Domains;

namespace HotelManagement.Controllers
{
    public class RoomServiceController : Controller
    {
        ICleanService cleanService;
        IRoomService roomService;
        public RoomServiceController(ICleanService clean , IRoomService room)
        {
            cleanService = clean;
            roomService = room;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RequestRoomService(string roompass)
        {
            var findRoom = roomService.GetByPassword(roompass);
            if (findRoom == null)
                return NotFound();

            return View();
        }


        [HttpPost]
        public IActionResult RequestRoomService(TbRoomService OroomService)
        {

            if (ModelState.IsValid)
            {
                TbRooms oroom = roomService.GetByRoomNo(OroomService.RoomNo);
                if (oroom == null)
                {
                    ViewBag.RoomNotFound = "There is no Room With this number please Enter your Room number";
                    return View(OroomService);
                }
                else if (oroom.Status == "Available")
                {
                    ViewBag.RoomNotFound = "This Room is Empty please Enter your Room number";
                    return View(OroomService);
                }
                else
                {
                    OroomService.Status = "Waiting";
                    cleanService.Add(OroomService);
                    return Redirect($"/Guests/GuestServices?roompass={oroom.RoomPassword}");
                }
            }

            return View(OroomService);
        }
    }
}
