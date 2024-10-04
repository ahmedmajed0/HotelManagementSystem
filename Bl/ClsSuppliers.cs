using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Bl
{
    public interface ISuplliersService
    {
        List<TbSuppliers> GetAll();
        TbSuppliers GetById(int Id);
        bool Add(TbSuppliers supplier);
        bool Edit(TbSuppliers supplier);
        bool Delete(TbSuppliers supplier);
    }


    public class ClsSuppliers : ISuplliersService
    {
        HotelManegementContext ctx;
        public ClsSuppliers (HotelManegementContext context)
        {
            ctx = context;
        }


        public List<TbSuppliers> GetAll()
        {
            return ctx.TbSuppliers.ToList();
        }


        public TbSuppliers GetById(int Id)
        {
            return ctx.TbSuppliers.Where(a => a.SupplierId == Id).FirstOrDefault();
        }


        public bool Add(TbSuppliers supplier)
        {
            try
            {
                ctx.Add<TbSuppliers>(supplier);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Edit(TbSuppliers supplier)
        {
            try
            {
                ctx.Entry(supplier).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(TbSuppliers supplier)
        {
            try
            {
                ctx.Remove<TbSuppliers>(supplier);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


    }
}
