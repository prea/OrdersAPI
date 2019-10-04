using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersModel.Repositories.Interface
{
    public interface IRepositoryWrap
    {
        
        IOrderRepository Order { get; }
        IUserRepository User { get; }

        void Save();
    }
}
