using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut12.Models;

namespace tut12.Configuration
{
    public class ConfectioneryEfConfiguration : IEntityTypeConfiguration<Confectionery>
    {
        public void Configure(EntityTypeBuilder<Confectionery> builder)
        {
            builder.Property(e => e.IdConfectionery).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.PricePerItem).IsRequired().HasColumnType("real");
            builder.Property(e => e.Type).IsRequired();
            builder.HasData(new Confectionery { IdConfectionery = 1, Name = "Macaron", PricePerItem =5.0,Type="type1"},
                                    new Confectionery { IdConfectionery = 2, Name = "Cake", PricePerItem = 7.5, Type = "type2" },
                                    new Confectionery { IdConfectionery = 3, Name = "Cookies", PricePerItem = 3.5, Type = "type3" });       
        }
    }
}
