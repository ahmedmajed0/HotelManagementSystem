using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bl
{

    public interface IClientService
    {
        List<TbClients> GetAll();
        TbClients GetById(int Id);
        bool Edit(TbClients oClient);

    }

    public class ClsClients : IClientService
    {
        HotelManegementContext ctx;
        public ClsClients(HotelManegementContext context)
        {
            ctx = context;
        }


        public List<TbClients> GetAll()
        {
            return ctx.TbClients.ToList();
        }


        public TbClients GetById(int Id)
        {
            return ctx.TbClients.Where(a => a.ClientId == Id).FirstOrDefault();
        }

        public bool Edit(TbClients oClient)
        {
            try
            {
                ctx.Entry(oClient).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
