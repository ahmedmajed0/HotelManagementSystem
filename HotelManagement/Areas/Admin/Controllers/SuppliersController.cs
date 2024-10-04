using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Bl;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize (Roles = "DataEntry")]
    public class SuppliersController : Controller
    {
        ISuplliersService suplliersService;
        IGoodsService goodsService;
        public SuppliersController(ISuplliersService service, IGoodsService goods )
        {
            suplliersService = service;
            goodsService = goods;
        }


        public IActionResult AllSuppliers()
        {
            return View(suplliersService.GetAll());
        }


        public IActionResult AddSupplier(int? Id)
        {
            if(Id != null)
            {
                TbSuppliers Osupplier =  suplliersService.GetById((int)Id);
                return View(Osupplier);
            }
            return View(new TbSuppliers());
        }


        [HttpPost]
        public IActionResult AddSupplier(TbSuppliers Supllier)
        {
            //ADD
            if(Supllier.SupplierId == 0)
            {
                if (ModelState.IsValid)
                {
                    suplliersService.Add(Supllier);
                    return Redirect("/Admin/Suppliers/AllSuppliers");
                }
                else
                {
                    return View(Supllier);
                }
            }
            //Edit
            else
            {
                if (ModelState.IsValid)
                {
                    suplliersService.Edit(Supllier);
                    return Redirect("/Admin/Suppliers/AllSuppliers");
                }
                else
                {
                    return View(Supllier);
                }
            }


        }

        public IActionResult Delete(int Id)
        {
            TbSuppliers osupplier = suplliersService.GetById(Id);
            suplliersService.Delete(osupplier);
            return RedirectToAction("AllSuppliers");
        }









        //SupplierGoods


        public IActionResult AllGoods()
        {
            var goods = goodsService.GetAll();
            if (goods.Count() == 0)
            {
                return View(new TbSupplierGoods());
            }

            return View(goodsService.GetAll());
        }

        public IActionResult AddGoods(int? Id)
        {
            ViewBag.Suppliers = suplliersService.GetAll(); 
            if(Id == null)
            {
                return View();
            }
            else
            {
                return View(goodsService.GetById((int)Id)); 
            }

            
        }


        [HttpPost]
        public IActionResult AddGoods(TbSupplierGoods oSupplierGood)
        {

            if (ModelState.IsValid)
            {
                //------setting supplier name-------
                TbSuppliers oSupplier = suplliersService.GetById(oSupplierGood.SupplierId);
                oSupplierGood.SupplierrName = oSupplier.SupplierName;
                //-------------


                if (oSupplierGood.SupplierGoodId == 0)
                {
                    goodsService.Add(oSupplierGood);
                    return RedirectToAction("AllGoods");
                }
                else
                {
                    goodsService.Edit(oSupplierGood);
                    return RedirectToAction("AllGoods");
                }
  
            }
            else
            {
                ViewBag.Suppliers = suplliersService.GetAll();
                return View(oSupplierGood);
            }

        }



    }
}
