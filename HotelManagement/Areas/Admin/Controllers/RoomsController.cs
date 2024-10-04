using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "DataEntry")]
    public class RoomsController : Controller
    {
        IRoomService roomService;
        IEmployeeService employeeService;
        IviewSerivice viewSerivice;
        public RoomsController(IRoomService service,IEmployeeService employee,IviewSerivice iview)
        {
            roomService = service;
            employeeService = employee;
            viewSerivice = iview;
        }



        public IActionResult AllRooms()
        {
            return View(roomService.GetAll());
        }

        public IActionResult AddRoom(int? Id)
        {
            ViewBag.HouseKeeping = employeeService.HouseKeepingEmp();
            ViewBag.Views = viewSerivice.GetAll();
            if (Id == null)
            {
                return View();
            }
            return View(roomService.GetById((int)Id));  
        }


        [HttpPost]
        public async Task<IActionResult> AddRoom(TbRooms oRoom, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                //AddImage
                if(Files.Count != 0)
                {
                    foreach (var file in Files)
                    {
                        if (file.Length > 0)
                        {
                            string ImageName = Guid.NewGuid().ToString() + ".jpg";
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                await file.CopyToAsync(stream);
                            }

                            oRoom.ImageName = ImageName;
                        }
                    }
                }
                else
                {
                    ViewBag.ImageError = "Please Select Image";
                    ViewBag.HouseKeeping = employeeService.HouseKeepingEmp();
                    ViewBag.Views = viewSerivice.GetAll();
                    return View(oRoom);
                }


                //------------------
                TbViews view = viewSerivice.GetById((int)oRoom.ViewId);
                TbEmployees employee = employeeService.GetById((int)oRoom.EmployeeId);
                oRoom.RoomCleaner = employee.EmployeeName;
                oRoom.RoomView = view.ViewName;
                //------------------

                if (oRoom.RoomId == 0)
                {
                    roomService.Add(oRoom);
                }
                else
                {
                    roomService.Edit(oRoom);
                }
                return RedirectToAction("AllRooms");
            }
            else
            {
                ViewBag.HouseKeeping = employeeService.HouseKeepingEmp();
                ViewBag.Views = viewSerivice.GetAll();
                return View(oRoom);
            }
        }






        //----------------------------------------------------
        //Views

        public IActionResult AllViews()
        {
            return View(viewSerivice.GetAll());
        }


        public IActionResult AddRoomsView(int? Id)
        {
            if(Id == null)
            {
                return View();
            }
            return View(viewSerivice.GetById((int)Id));
            
        }



        [HttpPost]
        public IActionResult AddRoomsView(TbViews oView)
        {


            if (ModelState.IsValid)
            {
                if (oView.ViewId == 0)
                {
                    viewSerivice.Add(oView);
                }
                else
                {
                    viewSerivice.Edit(oView);
                }
                return Redirect("/Admin/Rooms/AllViews");
            }
            else
            {
                return View(oView);
            }
        }



        public IActionResult DeleteView(int Id)
        {
            viewSerivice.Delete(viewSerivice.GetById(Id));
            return RedirectToAction("AllViews");
        }


    }
}
