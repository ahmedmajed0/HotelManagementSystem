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
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        IEmployeeService employeeService;
        public EmployeesController(IEmployeeService service)
        {
            employeeService = service;
        }



        public IActionResult AllEmployees()
        {
            return View(employeeService.GetAll());
        }

        public IActionResult AddEmployee(int? Id)
        {
            if(Id == null)
                return View();
            else
                return View(employeeService.GetById((int)Id));
        }
        [HttpPost]
        public IActionResult AddEmployee(TbEmployees oEmployee)
        {
            //DateTime Validation
            if (DateTime.Now < oEmployee.DateOfBirth)
            {
                ViewBag.dateError = "Invalid Date";
                return View(oEmployee);
            }
            var emp = employeeService.GetAll().Where(a => a.EmployeeNo == oEmployee.EmployeeNo).FirstOrDefault();
            if(emp != null && emp.EmployeeId != oEmployee.EmployeeId)
            {
                ModelState.AddModelError("EmployeeNo", "There is employee with this number");
                return View(oEmployee);
            }
            //Add
            if (oEmployee.EmployeeId == 0)
            {
                oEmployee.Age = DateTime.Now.Year - oEmployee.DateOfBirth.Year;
                if (ModelState.IsValid)
                {                 
                    employeeService.Add(oEmployee);
                    return Redirect("/Admin/Employees/AllEmployees");
                }
                return View(oEmployee);
            }
            //Edit
            else
            {
                if (ModelState.IsValid)
                {                   
                    oEmployee.Age = DateTime.Now.Year - oEmployee.DateOfBirth.Year;

                    employeeService.Edit(oEmployee);
                    return RedirectToAction("AllEmployees");
                }

                return View(oEmployee);
            }
        }
    }
}
