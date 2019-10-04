using OrdersModel.Context;
using OrdersModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdersModel.Repositories.Interface
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext applicationDBContext)
           : base(applicationDBContext)
        {
        }

    }
}
