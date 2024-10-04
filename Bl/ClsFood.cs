using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Bl
{
    public interface IFoodService
    {
        List<TbFood> GetAll();

        List<TbFoodCategory> GetAllCategoy();

        List<VwFoodCategory> GetAvailableCategory();

        TbFoodCategory GetCategoyById(int Id);
        TbFood GetById(int Id);
        bool Add(TbFood oMeel);
        bool Edit(TbFood oMeel);
        bool Delete(TbFood oMeel);


        bool AddCategory(TbFoodCategory category);
        bool EditCategory(TbFoodCategory category);
        bool DeleteCategory(TbFoodCategory category);

    }
    public class ClsFood: IFoodService
    {
        HotelManegementContext ctx;
        public ClsFood(HotelManegementContext contex)
        {
            ctx = contex;
        }

        public bool Add(TbFood oFood)
        {
            try
            {
                ctx.Add<TbFood>(oFood);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(TbFood oFood)
        {
            try
            {
                ctx.Remove<TbFood>(oFood);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(TbFood oFood)
        {
            try
            {
                ctx.Entry(oFood).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TbFood> GetAll()
        {
            return ctx.TbFood.ToList();
        }

        public List<TbFoodCategory> GetAllCategoy()
        {
            return ctx.TbFoodCategory.ToList();
        }


        public bool AddCategory(TbFoodCategory category)
        {
            try
            {
                ctx.Add<TbFoodCategory>(category);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCategory(TbFoodCategory category)
        {
            try
            {
                ctx.Remove<TbFoodCategory>(category);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditCategory(TbFoodCategory category)
        {
            try
            {
                ctx.Entry(category).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<VwFoodCategory> GetAvailableCategory()
        {
            return ctx.VwFoodCategory.ToList();
        }

        public TbFood GetById(int Id)
        {
            return ctx.TbFood.Where(a => a.FoodId == Id).FirstOrDefault();
        }

        public TbFoodCategory GetCategoyById(int Id)
        {
            return ctx.TbFoodCategory.Where(a => a.CategoryId == Id).FirstOrDefault();
        }
    }
}
