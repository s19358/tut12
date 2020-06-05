using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tut12.Models
{
    public class Confectionery
    {

        public Confectionery()
        {
            Confectionery_Orders = new HashSet<Confectionery_Order>();
        }
        [Key]
        public int IdConfectionery { get; set; }
        [MaxLength(200)]
        public string Name{ get; set; }
        public double PricePerItem{ get; set; }
        [MaxLength(40)]
        public string Type { get; set; }
        public virtual ICollection<Confectionery_Order> Confectionery_Orders { get; set; }

    }
}
