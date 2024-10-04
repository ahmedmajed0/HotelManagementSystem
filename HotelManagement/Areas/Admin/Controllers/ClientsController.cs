using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Receptionist")]
    public class ClientsController : Controller
    {
        IClientService clientService;

        public ClientsController(IClientService client)
        {
            clientService = client;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AllClients()
        {
            return View(clientService.GetAll());
        }


        public IActionResult Edit(int Id)
        {
            TbClients Oclient = clientService.GetById(Id);
            return View(Oclient);
        }


        [HttpPost]
        public IActionResult Edit(TbClients Oclient)
        {
            if (ModelState.IsValid)
            {
                clientService.Edit(Oclient);


                return RedirectToAction("AllClients");

            }

            return View(Oclient);

        }
    }
}
