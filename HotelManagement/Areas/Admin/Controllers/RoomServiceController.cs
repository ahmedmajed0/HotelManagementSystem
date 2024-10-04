using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "BasicUser")]
    public class RoomServiceController : Controller
    {
        IRoomService roomService;
        ICleanService cleanService;

        public RoomServiceController(IRoomService room, ICleanService clean)
        {
            roomService = room;
            cleanService = clean;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RequestRoomService(int? id)
        {
            if(id == null)
            {
                return View();
            }
            else
            {
                TbRoomService OroomService = cleanService.GetById((int)id);
                return View(OroomService);
            }
            
        }

  
        public IActionResult AllRequests()
        {
            return View(cleanService.GetAll());
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
                    if(OroomService.RoomServiceId == 0)
                    {
                        OroomService.Status = "Waiting";
                        cleanService.Add(OroomService);
                    }
                    else
                    {
                        cleanService.Edit(OroomService);
                    }
                    return RedirectToAction("AllRequests");
                }
            }

            return View(OroomService);
        }



        public IActionResult DeleteTodayRequests(List<TbRoomService> Model)
        {
            cleanService.DeleteAll(Model);
            return Redirect("/RoomService/AllRequests");
        }
    }
}
