using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut12.Models;

namespace tut12.DTOs
{
    public class NewOrderRequest
    {
        public DateTime DateAccepted { get; set; }
        public string Notes { get; set; }
        public IEnumerable<ConfectioneryRequest> Confectionery { get; set; }
    }
}
