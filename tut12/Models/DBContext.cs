using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut12.Configuration;

namespace tut12.Models
{
    public class DBContext : DbContext
    {

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Confectionery_Order> Confectionery_Order { get; set; }
        public DbSet<Confectionery> Confectionery { get; set; }

        public DBContext()
        {

        }
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerEfConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeEfConfiguration());
            modelBuilder.ApplyConfiguration(new ConfectioneryEfConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEfConfiguration());
            modelBuilder.ApplyConfiguration(new Conf_OrderEfConfiguration());

        }
    }
}
