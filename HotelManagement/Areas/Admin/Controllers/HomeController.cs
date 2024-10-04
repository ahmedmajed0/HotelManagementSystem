using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl;
using Microsoft.AspNetCore.Identity;
using HotelManagement.Areas.Admin.VwModel;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        IRoomService roomService;
        IReportService reportService;
        IEmployeeService employeeService;
        IOrderService orderService;
        IFoodService foodService;
        ICleanService cleanService;
        IClientService clientService;
        IMeelService meelService;
        ISuplliersService suplliersService;
        IviewSerivice iviewSerivice;
        IReservationService reservationService;
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;

        public HomeController(IRoomService room, IReportService report,
            IEmployeeService employee, IOrderService order,
            ICleanService clean, IClientService client, IFoodService  food,
            IMeelService meel, ISuplliersService supllier, IviewSerivice view,
            IReservationService reservation, UserManager<ApplicationUser> manager, RoleManager<IdentityRole> role)
        {
            roomService = room;
            reportService = report;
            employeeService = employee;
            orderService = order;
            foodService = food;
            cleanService = clean;
            clientService = client;
            meelService = meel;
            suplliersService = supllier;
            iviewSerivice = view;
            reservationService = reservation;
            userManager = manager;
            roleManager = role;

        }
        public IActionResult Index()
        {
            HomePageVwModel model = new HomePageVwModel();




            model.Admin.UsersNo = userManager.Users.Count();
            model.Admin.RolesNo = roleManager.Roles.Count();
            model.Admin.EmployeesNo = employeeService.GetAll().Count();
            model.Admin.RoomsNo = roomService.GetAll().Count();



            model.DataEntry.RoomsNo = model.Admin.RoomsNo;
            model.DataEntry.MealsNo = meelService.GetAll().Count();
            model.DataEntry.SuppliersNo = suplliersService.GetAll().Count();
            model.DataEntry.ViewsNo = iviewSerivice.GetAll().Count();



            model.Restaurant.FoodNo = foodService.GetAll().Count();
            model.Restaurant.OrdersNo = orderService.GetNormalOrders().Count();



            model.Receptionist.AvailableRooms = reportService.AvailableRooms().Count();
            model.Receptionist.CheckedRooms = reportService.CheckedRooms().Count();
            model.Receptionist.GuestsNo = reportService.GuestReport().Count();
            model.Receptionist.ReservationsNo = reservationService.GetAllReservations().Count();



            model.BasicUser.CheckedRooms = model.Receptionist.CheckedRooms;
            model.BasicUser.RoomsServRequests = cleanService.GetAll().Count();
            return View(model);
        }
    }
}
