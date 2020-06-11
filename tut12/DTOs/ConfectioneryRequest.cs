using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tut12.DTOs
{
    public class ConfectioneryRequest
    {


        [Required]
        public string Quantity { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}
