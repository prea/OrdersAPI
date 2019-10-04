using OrdersModel.Context;
using OrdersModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersUnitTest
{
    public static class DbContextExtensions
    {
        public static void Seed(this ApplicationDBContext dbContext)
        {
            // Add entities for DbContext instance

            dbContext.Orders.Add(new Order
            {
               DeliveryAddress ="test 1",
               OrderItems = new List<OrderItems>() {
                   new OrderItems{
                       ProductID =1,
                       Qty= 2 ,
                       UnitPrice= 5.5M
                   },
                   new OrderItems{
                         ProductID =2,
                       Qty= 4 ,
                       UnitPrice=3.5M
                   }
               }

            });
            dbContext.Orders.Add(new Order
            {
                DeliveryAddress = "test 2",
                OrderItems = new List<OrderItems>() {
                   new OrderItems{
                       ProductID =1,
                       Qty= 5 ,
                       UnitPrice= 15.5M
                   },
                   new OrderItems{
                         ProductID =2,
                       Qty= 10 ,
                       UnitPrice=15.5M
                   }
               }

            });

            dbContext.Orders.Add(new Order
            {
                DeliveryAddress = "test 3",
                OrderItems = new List<OrderItems>() {
                   new OrderItems{
                       ProductID =0,
                       Qty= 0 ,
                       UnitPrice= 15.5M
                   },
                   new OrderItems{
                         ProductID =2,
                       Qty= 8 ,
                       UnitPrice=15.5M
                   }
                   ,
                   new OrderItems{
                         ProductID =2,
                       Qty= 2 ,
                       UnitPrice=10.5M
                   }
               }

            });

            dbContext.Orders.Add(new Order
            {
                DeliveryAddress = "test 4",
                OrderItems = new List<OrderItems>() {
                   new OrderItems{
                       ProductID =123,
                       Qty=3 ,
                       UnitPrice= 1000
                   },
                   new OrderItems{
                         ProductID =33,
                       Qty= 8 ,
                       UnitPrice=15.5M
                   }
                   ,
                   new OrderItems{
                         ProductID =1233,
                       Qty= 2 ,
                       UnitPrice=89
                   }
               }

            });



            dbContext.SaveChanges();
        }
    }
}
