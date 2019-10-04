using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrdersModel.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersModel.Context
{
    public class ApplicationDBContext : DbContext
    {
        public int CurrentUserId { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
     

        public DbSet<OrderItems> OrderItems { get; set; }
        public ApplicationDBContext() { }

        public ApplicationDBContext(DbContextOptions options)
            : base(options)
        {
        }
        public static string _ConnectionString { get; set; }
   
     



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);            
            builder.Entity<OrderItems>().Property(p => p.UnitPrice).HasColumnType("decimal(6,2)");
            builder.Entity<Order>().Property(p => p.Total).HasColumnType("decimal(6,2)");

        }
        public override int SaveChanges()
        {
           
            return base.SaveChanges();
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
         
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }




    }
}
