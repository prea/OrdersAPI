using Microsoft.EntityFrameworkCore;
using OrdersModel.Context;
using OrdersModel.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrdersModel.Repositories
{
    /// <summary>
    /// Repository of Create and Read methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDBContext ApplicationDBContext { get; set; }

        public Repository(ApplicationDBContext applicationDBContext)
        {
            this.ApplicationDBContext = applicationDBContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.ApplicationDBContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ApplicationDBContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.ApplicationDBContext.Set<T>().Add(entity);
        }

        public T FindByID(int id)
        {
            return this.ApplicationDBContext.Set<T>().Find(id);
        }
    }
}
