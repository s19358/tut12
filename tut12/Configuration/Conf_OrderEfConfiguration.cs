using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut12.Models;

namespace tut12.Configuration
{
    public class Conf_OrderEfConfiguration : IEntityTypeConfiguration<Confectionery_Order>
    {
        public void Configure(EntityTypeBuilder<Confectionery_Order> en)
        {

            en.HasKey(e => new { e.IdConfectionery, e.IdOrder });
            en.Property(e => e.Notes).IsRequired();
            en.HasData(
                new Confectionery_Order{IdConfectionery=1,IdOrder=1,Quantity=25,Notes="note1"},
                new Confectionery_Order { IdConfectionery = 2, IdOrder = 2, Quantity = 30, Notes = "note2" },
                new Confectionery_Order { IdConfectionery = 3, IdOrder = 3, Quantity = 20, Notes = "note3" });


        }
    }
}
