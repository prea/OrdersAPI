using Microsoft.EntityFrameworkCore;
using OrdersModel.Context;
using OrdersModel.Model;
using OrdersModel.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrdersModel.Repositories
{
    /// <summary>
    ///  Repository of Order 
    /// </summary>
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDBContext applicationDBContext)
           : base(applicationDBContext)
        {
        }

        public List<string> ValidateOrder(Order order)
        {
          
            List<String> listErrors = new List<string>();
            List<OrderItems> checkOrderItems = new List<OrderItems>();

            //Load values inserted in database to same order
            if (order.Id > 0 && order.OrderItems.Count > 0)
            {

                var checkOrder = ApplicationDBContext.Orders.Where(w => w.Id == order.Id).FirstOrDefault();
                if (checkOrder != null)
                {
                    checkOrderItems = ApplicationDBContext.OrderItems.Where(w => w.OrderID == order.Id).ToList();

                }
                else {
                    listErrors.Add(String.Format("The Order ID '{0}' is invalid!", order.Id));
                }
            }
            //check if the total >  100 and is a product has more than 10 items
            foreach (var orderItem in order.OrderItems)
            {
               
                int itemsCreated = orderItem.Qty;
                if (checkOrderItems.Count > 0)
                {
                    itemsCreated += checkOrderItems.Where(w => w.ProductID == orderItem.ProductID).Select(s => s.Qty).FirstOrDefault();
                }
                if (itemsCreated > 10)
                {
                    listErrors.Add(String.Format("The ProductID {0} has more than 10 items", orderItem.ProductID));
                }
            }
            decimal total = getTotal(order);
            if (total > 100)
            {
                listErrors.Add("The orders have a total value in excess of one hundred Euro");

            }
            return listErrors;
        }

        private decimal getTotal(Order order) {
            decimal total = 0;
            List<OrderItems> checkOrderItems = new List<OrderItems>();
            if (order.Id > 0 && order.OrderItems.Count > 0)
            {

                var checkOrder = ApplicationDBContext.Orders.Where(w => w.Id == order.Id).FirstOrDefault();
                if (checkOrder != null)
                {
                    checkOrderItems = ApplicationDBContext.OrderItems.Where(w => w.OrderID == order.Id).ToList();
                    foreach (var orderItem in checkOrderItems)
                    {
                        total += orderItem.UnitPrice * orderItem.Qty;

                    }
                }
            }
            foreach (var orderItem in order.OrderItems)
            {
                total += orderItem.UnitPrice * orderItem.Qty;
            }

            return total;
        }

        public new IQueryable<Order> FindAll() {
           var listOrder =    ApplicationDBContext.Set<Order>().AsNoTracking().ToList();
            if (listOrder.Count > 0) {
                foreach (var item in listOrder)
                {
                    item.OrderItems = ApplicationDBContext.OrderItems.Where(w => w.OrderID == item.Id).ToList();
                }
            }

            return listOrder.AsQueryable();
        }
        public new Order FindByID(int id)
        {
            var listOrder = ApplicationDBContext.Set<Order>().AsNoTracking().Where(w=>w.Id ==id).FirstOrDefault();
            if (listOrder != null)
            {

                listOrder.OrderItems = ApplicationDBContext.OrderItems.Where(w => w.OrderID == listOrder.Id).ToList();
                
            }

            return listOrder;
        }

        

        public new void Create(Order entity)
        {
            entity.Total = getTotal(entity);
            if (entity.Id > 0)
            {
                this.ApplicationDBContext.Set<Order>().Update(entity);
            }
            else {
                this.ApplicationDBContext.Set<Order>().Add(entity);
            }
            
        }
    }
}
