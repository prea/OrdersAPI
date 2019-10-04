using OrdersModel.Model;
using OrdersModel.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersModel.Repositories.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
         List<String> ValidateOrder(Order order);
    }
}
