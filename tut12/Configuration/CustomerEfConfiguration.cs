using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut12.Models;

namespace tut12.Configuration
{
    public class CustomerEfConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.Property(e => e.IdClient).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Surname).IsRequired();
            builder.HasData(new Customer
            {
                IdClient = 1,
                Name = "Aysenur",
                Surname = "Ozgur"
            },

               new Customer
               {
                   IdClient = 2,
                   Name = "Merve",
                   Surname = "Unal"
               },
                 new Customer
                 {
                     IdClient = 3,
                     Name = "Busra",
                     Surname = "Yilmaz"
                 }
              

            );
        }
    }
}
