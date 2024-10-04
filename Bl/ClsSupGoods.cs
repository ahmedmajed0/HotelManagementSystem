using Domains;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Bl
{
    public interface IGoodsService 
    {
        List<TbSupplierGoods> GetAll();
        TbSupplierGoods GetById(int Id);
        bool Add(TbSupplierGoods oSupGoods);
        bool Edit(TbSupplierGoods oSupGoods);
        bool Delete(TbSupplierGoods oSupGoods);
    }

    public class ClsSupGoods : IGoodsService
    {

        HotelManegementContext ctx;
        public ClsSupGoods(HotelManegementContext context)
        {
            ctx = context;
        }

        public bool Add(TbSupplierGoods oSupGoods)
        {
            try
            {
                oSupGoods.PaymentDate = DateTime.Today;
                ctx.Add<TbSupplierGoods>(oSupGoods);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public bool Delete(TbSupplierGoods oSupGoods)
        {
            try
            {
                ctx.Remove<TbSupplierGoods>(oSupGoods);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Edit(TbSupplierGoods oSupGoods)
        {
            try
            {
                ctx.Entry(oSupGoods).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<TbSupplierGoods> GetAll()
        {
            return ctx.TbSupplierGoods.ToList();
        }

        public TbSupplierGoods GetById(int Id)
        {
            return ctx.TbSupplierGoods.Where(a => a.SupplierGoodId == Id).FirstOrDefault();
        }
    }
}
