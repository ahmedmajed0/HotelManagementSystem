using System;
using System.Collections.Generic;
using System.Text;
using Bl;
using Domains;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bl
{
    public interface ICleanService
    {
        TbRoomService GetById(int Id);
        bool Add(TbRoomService oRoomService);
        bool Edit(TbRoomService oRoomService);
        bool Delete(TbRoomService oRoomService);

        bool DeleteAll(List<TbRoomService> oRoomService);

        List<TbRoomService> GetAll();

        List<TbRoomService> GetAllToday();
    }

    public class ClsRoomService : ICleanService
    {
        HotelManegementContext ctx;
        public ClsRoomService(HotelManegementContext contex)
        {
            ctx = contex;
        }

        public TbRoomService GetById(int Id)
        {
            return ctx.TbRoomService.Where(a => a.RoomServiceId == Id).FirstOrDefault();
        }

        public bool Add(TbRoomService oRoomService)
        {
            try
            {
                ctx.Add<TbRoomService>(oRoomService);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(TbRoomService oRoomService)
        {
            try
            {
                ctx.Entry(oRoomService).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(TbRoomService oRoomService)
        {
            try
            {
                ctx.Remove<TbRoomService>(oRoomService);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<TbRoomService> GetAll()
        {
            return ctx.TbRoomService.OrderBy(a => a.CleaningDay).ThenBy(a => a.PM).ThenBy(a => a.RecievingHour).ToList();
        }

        public List<TbRoomService> GetAllToday()
        {
            return ctx.TbRoomService.Where(a => a.CleaningDay == "Today").OrderBy(a => a.CleaningDay).ThenBy(a => a.PM).ThenBy(a => a.RecievingHour).ToList();
        }

        public bool DeleteAll(List<TbRoomService> Requests)
        {
            try
            {
                foreach (var request in Requests)
                {
                    ctx.Remove<TbRoomService>(request);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
