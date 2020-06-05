using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tut12.Models
{
    public class Order
    {

        public Order()
        {
            Confectionery_Orders = new HashSet<Confectionery_Order>();
        }
        [Key]
        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        [MaxLength(255)]
        public string Notes { get; set; }

        [ForeignKey("Customer")]
        public int IdClient { get; set; }
        [ForeignKey("Employee")]
        public int IdEmployee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<Confectionery_Order> Confectionery_Orders { get; set; }

    }
}
