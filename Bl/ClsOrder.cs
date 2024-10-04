using System;
using System.Collections.Generic;
using System.Text;
using Bl;
using Domains;
using System.Linq;

namespace Bl
{
    public interface IOrderService
    {
        int AddClientFood(TbClientFood OclientFood);

        bool AddOrder(List<TbOrder> listOrders, int ClFoodId);

        bool UpdateStatus(int ClFoodId);

        List<VwClientFoodPayment>ClientFoodUnpaid(int RoomNo);

        bool AddPayment(int ClFoodId, decimal total);



        bool DeletePayment(int ClFoodId);

        bool DeleteOrder(int ClFoodId);

        bool DeleteClientFood(int ClFoodId);

        List<VwClientOrder> GetNormalOrders();

    }
    public class ClsOrder : IOrderService
    {
        HotelManegementContext ctx;
        public ClsOrder(HotelManegementContext context)
        {
            ctx = context;
        }
        public int AddClientFood(TbClientFood OclientFood)
        {
            try
            {
                if(OclientFood.RecievingHour != 0)
                {
                    OclientFood.Status = "Special";
                }
                else if(OclientFood.RecievingHour == 0)
                {
                    OclientFood.Status = "Waiting";
                }
                ctx.TbClientFood.Add(OclientFood);
                ctx.SaveChanges();

                TbClientFood obj = ctx.TbClientFood.OrderByDescending(a => a.ClientFoodId).FirstOrDefault();

                return obj.ClientFoodId;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        public bool AddOrder(List<TbOrder> listOrders, int ClFoodId)
        {
            try
            {
                foreach (var Order in listOrders)
                {
                    Order.ClientFoodId = ClFoodId;
                    ctx.TbOrder.Add(Order);
                    ctx.SaveChanges();
                }
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool AddPayment(int ClFoodId, decimal total)
        {
            try
            {
                TbPayments oPayment = new TbPayments();
                oPayment.ClientFoodId = ClFoodId;
                oPayment.TotalPaidPrice = total;
                oPayment.PaymentDate = DateTime.Now;

                oPayment.PaymentStatus = "Un paid";


                ctx.TbPayments.Add(oPayment);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<VwClientFoodPayment> ClientFoodUnpaid(int RoomNo)
        {
            return ctx.VwClientFoodPayment.Where(a => a.RoomNo == RoomNo).ToList();
        }

        public bool DeleteClientFood(int ClFoodId)
        {
            var OclientFood = ctx.TbClientFood.Where(a => a.ClientFoodId == ClFoodId).FirstOrDefault();

            try
            {
                ctx.Remove<TbClientFood>(OclientFood);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool DeleteOrder(int ClFoodId)
        {
            var clientOrders = ctx.TbOrder.Where(a => a.ClientFoodId == ClFoodId).ToList();

            try
            {
                foreach (var order in clientOrders)
                {
                    ctx.Remove<TbOrder>(order);
                }
                ctx.SaveChanges();

                DeletePayment(ClFoodId);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        public bool DeletePayment(int ClFoodId)
        {
            var lstPayments = ctx.TbPayments.Where(a => a.ClientFoodId == ClFoodId).ToList();

            try
            {
                foreach(var payment in lstPayments)
                {
                    ctx.Remove<TbPayments>(payment);
                }
                ctx.SaveChanges();

                DeleteClientFood(ClFoodId);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<VwClientOrder> GetNormalOrders()
        {
            return ctx.VwClientOrder.Where(a => a.Status == "Waiting").OrderBy(a => a.Date).ToList();
        }

        public bool UpdateStatus(int ClFoodId)
        {
            try
            {
                List<TbClientFood> OclientFoods = ctx.TbClientFood.Where(e => e.ClientFoodId == ClFoodId).ToList();
                var waitingClientFood = OclientFoods.Where(a => a.Status == "Waiting").FirstOrDefault();
                waitingClientFood.Status = "Done";
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
