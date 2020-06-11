using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tut12.DTOs;
using tut12.Models;
using tut12.Services;

namespace tut12.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class NewOrderController : ControllerBase
    {


        IOrderDbService _service;
        public NewOrderController(IOrderDbService service)
        {
            _service = service;
        }

        [HttpPost("{id}/orders")]
        public IActionResult newOrder(int id,NewOrderRequest req)
        {
            var res = _service.newOrder(id, req);
            return Ok(res);
        }


    }
}