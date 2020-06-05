using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tut12.Models
{
    public class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        public int IdEmployee { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(60)]
        public string Surname { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
