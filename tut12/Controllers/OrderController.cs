using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tut12.Models;
using tut12.Services;

namespace tut12.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private readonly DBContext _dbcontext;  //db

       
        IOrderDbService _service;
        public OrderController(IOrderDbService service)
        {
            _service = service;
        }


        [HttpGet("{name?}")]
        public IActionResult getOrders(string? name)
        {

            var en = _service.getOrders(name);
            return Ok(en);


        }
    }
}