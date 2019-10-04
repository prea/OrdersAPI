using OrdersModel.Context;
using OrdersModel.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersModel.Repositories
{

    /// <summary>
    /// A wrapper aroud the list of repository classes
    /// </summary>
    public class RepositoryWrap : IRepositoryWrap
    {
        private ApplicationDBContext _applicationDBContext;
        private IOrderRepository _order;
        private IUserRepository _user;      
        private IOrderItemsRepository _orderItems;
      
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_applicationDBContext);
                }
                return _user;
            }
        }
        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_applicationDBContext);
                }
                return _order;
            }
        }
        public IOrderItemsRepository OrderItems
        {
            get
            {
                if (_orderItems == null)
                {
                    _orderItems = new OrderItemsRepository(_applicationDBContext);
                }
                return _orderItems;
            }
        }
        public RepositoryWrap(ApplicationDBContext applicationDBContext) {
            _applicationDBContext = applicationDBContext;
        }

        public void Save()
        {
            _applicationDBContext.SaveChanges();
        }
    }
}
