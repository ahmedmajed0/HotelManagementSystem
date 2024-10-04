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
    [Authorize(Roles = "Restaurant")]
    public class OrdersController : Controller
    {
        IOrderService orderService;
        public OrdersController(IOrderService order)
        {
            orderService = order;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NormalOrders()
        {
            NormalOrdersModel Model = new NormalOrdersModel();
            Model.clientOrders = orderService.GetNormalOrders();
            Model.SampleOrders = Model.clientOrders.GroupBy(a => a.ClientFoodId).Select(a => a.First()).ToList();
            VwClientOrder order = Model.clientOrders.FirstOrDefault();

            return View(Model);
        }


        public IActionResult OrderDone(int ClFoodId)
        {
            orderService.UpdateStatus(ClFoodId);

            return RedirectToAction("NormalOrders");
        }

        
    }
}
