using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Bl
{
    public interface IEmployeeService
    {
        List<TbEmployees> GetAll();
        List<TbEmployees> HouseKeepingEmp();
        TbEmployees GetById(int Id);
        bool Add(TbEmployees oEmployee);
        bool Edit(TbEmployees oEmployee);
        bool Delete(TbEmployees oEmployee);

    }
    public class ClsEmplyees : IEmployeeService
    {
        HotelManegementContext ctx;
        IRoomService roomService;
        public ClsEmplyees(HotelManegementContext context, IRoomService room)
        {
            ctx = context;
            roomService = room;
        }

        public List<TbEmployees> GetAll()
        {
            return ctx.TbEmployees.ToList();
        }

        List<TbEmployees> IEmployeeService.HouseKeepingEmp()
        {
            return ctx.TbEmployees.Where(a => a.DepartMent == "HouseKepping").ToList();
        }

        public TbEmployees GetById(int Id)
        {
            return ctx.TbEmployees.Where(a => a.EmployeeId == Id).FirstOrDefault();
        }



        public bool Add(TbEmployees oEmployee)
        {
            try
            {
                ctx.Add<TbEmployees>(oEmployee);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(TbEmployees oEmployee)
        {
            try
            {
                if(oEmployee.DepartMent == "HouseKepping")
                {
                    var rooms = roomService.GetAll();
                    var HouskeeperRooms = rooms.Where(a => a.EmployeeId == oEmployee.EmployeeId).ToList();
                    foreach(var room in HouskeeperRooms)
                    {
                        room.EmployeeId = null;
                        room.RoomCleaner = "None";
                        roomService.Edit(room);
                    }
                }
                ctx.Remove<TbEmployees>(oEmployee);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Edit(TbEmployees oEmployee)
        {
            try
            {
                var OldEmp = GetById(oEmployee.EmployeeId);

                OldEmp .Age= oEmployee.Age;
                OldEmp.DateOfBirth = oEmployee.DateOfBirth;
                OldEmp.EmployeeName = oEmployee.EmployeeName;
                OldEmp.EmployeeNo = oEmployee.EmployeeNo;
                OldEmp.JobName = oEmployee.JobName;
                OldEmp.Salary = oEmployee.Salary;
                OldEmp.DepartMent = oEmployee.DepartMent;
                ctx.SaveChanges();
                   return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

    }
}






 