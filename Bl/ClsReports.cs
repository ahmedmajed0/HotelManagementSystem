using System;
using System.Collections.Generic;
using System.Text;
using Bl;
using Domains;
using System.Linq;

namespace Bl
{
    public interface IReportService 
    {
        List<VwClientRoom> GuestReport();

        List<VwRoomMeel> RoomMeelsReport();

        List<VwMeelNumber> MeelNoReport();

        List<VwRoomReservation> AllReservationsReport();

        List<VwRoomEmployee> HouseKeepingReport();

        List<VwRoomReservedEmployee> DailyHouseKeepingReport();


        List<VwRooms> CheckedRooms();

        List<TbRooms> AvailableRooms();

        List<TbPayments> TodayImports();

        List<TbSupplierGoods> TodayExports();
    }

    public class ClsReports : IReportService
    {
        HotelManegementContext ctx;
        public ClsReports(HotelManegementContext context)
        {
            ctx = context;
        }

        public List<VwRoomReservation> AllReservationsReport()
        {
            return ctx.VwRoomReservation.ToList();
        }

        public List<VwRoomReservedEmployee> DailyHouseKeepingReport()
        {
            return ctx.VwRoomReservedEmployee.ToList();
        }

        public List<VwClientRoom> GuestReport()
        {
            return ctx.VwClientRoom.ToList();
        }

        public List<VwRoomEmployee> HouseKeepingReport()
        {
            return ctx.VwRoomEmployee.OrderBy(a => a.EmployeeName).ToList();
        }

        public List<VwMeelNumber> MeelNoReport()
        {
            return ctx.VwMeelNumber.ToList();
        }

        public List<VwRoomMeel> RoomMeelsReport()
        {
            return ctx.VwRoomMeel.OrderBy(a => a.MeelName).ToList();
        }


        public List<VwRooms> CheckedRooms()
        {
            return ctx.VwRooms.Where(a => a.Status == "Checked").ToList();
        }

        public List<TbRooms> AvailableRooms()
        {
            return ctx.TbRooms.Where(a => a.Status == "Available").ToList();
        }

        public List<TbPayments> TodayImports()
        {
            return ctx.TbPayments.Where(a => a.PaymentDate.Date == DateTime.Today).ToList();
        }

        public List<TbSupplierGoods> TodayExports()
        {
            return ctx.TbSupplierGoods.Where(a => a.PaymentDate.Date == DateTime.Today).ToList();
        }
    }
}
