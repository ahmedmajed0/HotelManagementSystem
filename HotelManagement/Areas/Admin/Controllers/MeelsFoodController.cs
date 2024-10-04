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
    public class MeelsFoodController : Controller
    {
        IFoodService foodService;
        IMeelService meelService;
        
        public MeelsFoodController(IMeelService service,IFoodService food)
        {
            meelService = service;
            foodService = food;
        }


        [Authorize(Roles = "DataEntry")]
        public IActionResult AllMeels()
        {
            return View(meelService.GetAll());
        }

        [Authorize(Roles = "DataEntry")]
        public IActionResult AddMeel(int? Id)
        {
            if(Id == null)
            {
                return View();
            }
            return View(meelService.GetById((int)Id));
            
        }


        [Authorize(Roles = "DataEntry")]
        [HttpPost]
        public IActionResult AddMeel(TbMeels meel)
        {

            if (ModelState.IsValid)
            {
                if (meel.MeelId == 0)
                {
                    meelService.Add(meel);
                }
                else
                {
                    meelService.Edit(meel);
                }
                return Redirect("/Admin/MeelsFood/AllMeels");
            }
            else
            {
                return View(meel);
            }
        }



        //-----------------------------------------------------------------

        //Food


        [Authorize(Roles = "Restaurant")]
        public IActionResult AllFoods()
        {
            return View(foodService.GetAll());
        }



        [Authorize(Roles = "Restaurant")]
        public IActionResult AddCategory(int? Id)
        {
            if (Id == null)
            {
                return View();
            }
            return View(foodService.GetCategoyById((int)Id));

        }


        [Authorize(Roles = "Restaurant")]
        [HttpPost]
        public IActionResult AddCategory(TbFoodCategory category)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryId == 0)
                {
                    foodService.AddCategory(category);
                }
                else
                {
                    foodService.EditCategory(category);
                }
                return Redirect("/Admin/MeelsFood/AllCategory");
            }
            else
            {
                return View(category);
            }
        }




        [Authorize(Roles = "Restaurant")]
        public IActionResult AllCategory()
        {
            return View(foodService.GetAllCategoy());
        }


        [Authorize(Roles = "Restaurant")]
        public IActionResult AddFood(int? Id)
        {
            ViewBag.Categories = foodService.GetAllCategoy();
            if (Id == null)
            {
                return View();
            }
            return View(foodService.GetById((int)Id));

        }

        [Authorize(Roles = "Restaurant")]
        [HttpPost]
        public async Task<IActionResult> AddFood(TbFood food, List<IFormFile> Files)
        {
            food.FoodImage = "image";
            if (ModelState.IsValid)
            {
                //AddImage
                foreach(var file in Files)
                {
                    if(file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(stream);
                        }

                        food.FoodImage = ImageName;
                    }
                }

                TbFoodCategory category = foodService.GetCategoyById(food.CategoryId);
                food.CategoryName = category.CategoryName;

                if (food.FoodId == 0)
                {
                    foodService.Add(food);
                }
                else
                {
                    foodService.Edit(food);
                }
                return Redirect("/Admin/MeelsFood/AllFoods");
            }
            else
            {
                ViewBag.Categories = foodService.GetAllCategoy();
                return View(food);
            }
        }

    }
}
