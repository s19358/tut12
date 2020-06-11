using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut12.Models;

namespace tut12.Configuration
{
    public class OrderEfConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.Property(e => e.IdOrder).ValueGeneratedOnAdd();
            builder.Property(e => e.Notes).IsRequired();
            builder.Property(e => e.DateAccepted).HasColumnType("date");
            builder.Property(e => e.DateFinished).HasColumnType("date");
            builder.HasData(
                new Order { IdOrder = 1, DateAccepted = new DateTime(2020, 5, 1), DateFinished = new DateTime(2020, 6, 1), Notes = "note1", IdClient = 1, IdEmployee = 1 },
                new Order { IdOrder = 2, DateAccepted = new DateTime(2020, 4, 1), DateFinished = new DateTime(2020, 4, 15), Notes = "note2", IdClient = 2, IdEmployee = 2 },
                new Order { IdOrder = 3, DateAccepted = new DateTime(2020, 2, 25), DateFinished = new DateTime(2020, 3, 20), Notes = "note3", IdClient = 3, IdEmployee = 3 });


        }
    }
}
