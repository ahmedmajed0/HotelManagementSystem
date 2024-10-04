using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Bl;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class RoomsController : Controller
    {
        IRoomService roomService;
        public RoomsController(IRoomService service)
        {
            roomService = service;
        }



        public IActionResult ShowRoom(int Id)
        {
            TbRooms oRoom = roomService.GetById(Id);
            RoomModel model = new RoomModel();

            model.SingleRoom = oRoom;
            model.lstRelatedRooms = roomService.GetRelatedRooms(oRoom.NoOfBeds);
            model.lstBigRooms = roomService.GetBigRooms();
            return View(model);
        }



    }
}
