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
    ///  Repository of Order  Items
    /// </summary>
    public class OrderItemsRepository : Repository<OrderItems>, IOrderItemsRepository
    {
        protected ApplicationDBContext ApplicationDBContext { get; set; }
        public OrderItemsRepository(ApplicationDBContext applicationDBContext)
           : base(applicationDBContext)
        {
            ApplicationDBContext = applicationDBContext;
        }
    
    }
}
