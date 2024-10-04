using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl;
using Domains;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class FoodController : Controller
    {
        IFoodService foodService;
        IOrderService orderService;
        IRoomService roomService;
        public FoodController(IFoodService food, IOrderService order, IRoomService room)
        {
            foodService = food;
            orderService = order;
            roomService = room;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FoodList(string roompass)
        {
            var findRoom = roomService.GetByPassword(roompass);
            if (findRoom == null)
                return NotFound();
            return View();
        }

        public IActionResult SingleFood(int id)
        {
            TbFood food = foodService.GetById(id);
            return View(food);
        }

        public IActionResult AddOrder(int id)
        {
            OrderMenu orderMenu = HttpContext.Session.GetObjectFromJson<OrderMenu>("Menu");
            if (orderMenu == null)
                orderMenu = new OrderMenu();

            TbFood food= foodService.GetById(id);
            TbOrder orderItem = orderMenu.listOrders.Where(a => a.FoodId == id).FirstOrDefault();
            if (orderItem != null)
            {
                orderItem.qty++;
                orderItem.Total = orderItem.qty * orderItem.Price;

            }
            else
            {

                orderMenu.listOrders.Add(new TbOrder()
                {
                    FoodId = food.FoodId,
                    Image = food.FoodImage,
                    FoodName = food.FoodName,
                    Price = food.FoodPrice,
                    qty = 1,
                    Total = food.FoodPrice,
                });
            }
            orderMenu.Total = orderMenu.listOrders.Sum(a => a.Total);
            HttpContext.Session.SetObjectAsJson("Menu", orderMenu);

            return RedirectToAction("OrderItems");
        }     

        public IActionResult OrderItems()
        {
            OrderMenu orderMenu = HttpContext.Session.GetObjectFromJson<OrderMenu>("Menu");
            return View(orderMenu);
        }

        public IActionResult RemoveOrderItem(int id)
        {
            OrderMenu orderMenu = HttpContext.Session.GetObjectFromJson<OrderMenu>("Menu");
            orderMenu.listOrders.Remove(orderMenu.listOrders.Where(a => a.FoodId == id).FirstOrDefault());
            orderMenu.Total = orderMenu.listOrders.Sum(a => a.Total);
            HttpContext.Session.SetObjectAsJson("Menu", orderMenu);

            return RedirectToAction("OrderItems");
        }


        public IActionResult SaveOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveOrder(TbClientFood OclientFood)
        {
            OrderMenu orderMenu = HttpContext.Session.GetObjectFromJson<OrderMenu>("Menu");

            var room = roomService.GetByRoomNo(OclientFood.RoomNo);
            if(room == null)
            {
                ModelState.AddModelError("RoomNo", "No room with this number");
                return View(OclientFood);
            }
            if (room.Status == "Available")
            {
                ModelState.AddModelError("RoomNo", "NO guests in this room");
                return View(OclientFood);
            }
            if (ModelState.IsValid)
            {

                OclientFood.Date = DateTime.Now;
                OclientFood.Price = orderMenu.Total;

                int id = orderService.AddClientFood(OclientFood);

                List<TbOrder> listorders = orderMenu.listOrders;

                orderService.AddOrder(listorders, id);

                orderService.AddPayment(id , orderMenu.Total);

                HttpContext.Session.Remove("Menu");
                return Redirect($"/Guests/GuestServices?roompass={room.RoomPassword}");

            }
            return View(OclientFood);
        }
    }
}
