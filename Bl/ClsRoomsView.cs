using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Bl
{
    public interface IviewSerivice 
    {
        List<TbViews> GetAll();
        TbViews GetById(int Id);
        bool Add(TbViews oView);
        bool Edit(TbViews oView);
        bool Delete(TbViews oView);
    }

    public class ClsRoomsView: IviewSerivice
    {
        HotelManegementContext ctx;
        public ClsRoomsView(HotelManegementContext contex)
        {
            ctx = contex;
        }

        public bool Add(TbViews oView)
        {
            try
            {
                ctx.Add<TbViews>(oView);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(TbViews oView)
        {
            try
            {
                ctx.Remove<TbViews>(oView);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(TbViews oView)
        {
            try
            {
                ctx.Entry(oView).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TbViews> GetAll()
        {
            return ctx.TbViews.ToList();
        }

        public TbViews GetById(int Id)
        {
            return ctx.TbViews.Where(a => a.ViewId == Id).FirstOrDefault();
        }
    }
}
