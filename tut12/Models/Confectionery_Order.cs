using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace tut12.Models
{
    public class Confectionery_Order
    {
        [ForeignKey("Confectionery")]
        public int IdConfectionery { get; set; }
        [ForeignKey("Order")]
        public int IdOrder { get; set; }
        public int Quantity { get; set; }
        [MaxLength(255)]
        public string Notes { get; set; }
        public virtual Confectionery Confectionery { get; set; }
        public virtual Order Order { get; set; }
    }
}
