using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut12.Models;

namespace tut12.Configuration
{
    public class EmployeeEfConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> en)
        {
          
                en.Property(e => e.IdEmployee).ValueGeneratedOnAdd();
                en.Property(e => e.Name).IsRequired();
                en.Property(e => e.Surname).IsRequired();
                en.HasData(new Employee
                {
                    IdEmployee = 1,
                    Name = "Reyhan",
                    Surname = "Ozgur"
                },

               new Employee
               {
                   IdEmployee = 2,
                   Name = "Simal",
                   Surname = "Can"
               },
                 new Employee
                 {
                     IdEmployee = 3,
                     Name = "Ali",
                     Surname = "Yilmaz"
                 });

          
        }
    }
}
