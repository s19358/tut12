using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tut12.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int IdClient { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(60)]
        public string Surname { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
