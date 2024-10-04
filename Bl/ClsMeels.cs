using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Bl
{
    public interface IMeelService 
    {
        List<TbMeels> GetAll();
        TbMeels GetById(int Id);

        decimal GetPriceById(int Id);
        bool Add(TbMeels oMeel);
        bool Edit(TbMeels oMeel);
        bool Delete(TbMeels oMeel);
    }

    public class ClsMeels : IMeelService
    {
        HotelManegementContext ctx;
        public ClsMeels(HotelManegementContext contex)
        {
            ctx = contex;
        }

        public bool Add(TbMeels oMeel)
        {
            try
            {
                ctx.Add<TbMeels>(oMeel);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(TbMeels oMeel)
        {
            try
            {
                ctx.Remove<TbMeels>(oMeel);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(TbMeels oMeel)
        {
            try
            {
                ctx.Entry(oMeel).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TbMeels> GetAll()
        {
            return ctx.TbMeels.ToList();
        }

        public TbMeels GetById(int Id)
        {
            return ctx.TbMeels.Where(a => a.MeelId == Id).FirstOrDefault();
        }

        public decimal GetPriceById(int Id)
        {
            TbMeels Omeel = ctx.TbMeels.Where(a => a.MeelId == Id).FirstOrDefault();
            return Omeel.MeelPrice;
        }
    }
}
