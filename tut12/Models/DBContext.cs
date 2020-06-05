using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            //FluentAPI

            modelBuilder.Entity<Confectionery_Order>(en =>
            {
                en.HasKey(e => new { e.IdConfectionery, e.IdOrder });

            });


            modelBuilder.Entity<Customer>(en =>
            {
                en.Property(e => e.IdClient).ValueGeneratedOnAdd();
                en.Property(e => e.Name).IsRequired();
                en.Property(e => e.Surname).IsRequired();

            });
            modelBuilder.Entity<Employee>(en =>
            {
                en.Property(e => e.IdEmployee).ValueGeneratedOnAdd();
                en.Property(e => e.Name).IsRequired();
                en.Property(e => e.Surname).IsRequired();

            });
            modelBuilder.Entity<Confectionery>(en =>
            {
                en.Property(e => e.IdConfectionery).ValueGeneratedOnAdd();
                en.Property(e => e.Name).IsRequired();
                en.Property(e => e.PricePerItem).IsRequired();
                en.Property(e => e.Type).IsRequired();

            });
            modelBuilder.Entity<Order>(en =>
            {
                en.Property(e => e.IdOrder).ValueGeneratedOnAdd();
            });
        }
    }
}
