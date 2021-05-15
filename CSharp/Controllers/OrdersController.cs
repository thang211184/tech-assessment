using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp.Data.Models;
using CSharp.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        // GET api/orders
        [HttpGet]
        public ActionResult<List<Order>> Get([FromQuery]string name)
        {
            var orders = _service.GetOrders();

            if (!string.IsNullOrEmpty(name))
            {
                orders = orders.Where(o => o.CustomerName.ToLower()==(name.ToLower())).ToList();
            }
                 
            return Ok(orders);
        }

        // GET: api/Orders/id
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // Post api/orders
        [HttpPost]
        public ActionResult Post([FromBody] Order value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _service.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        // Delete api/orders/id
        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var existingItem = _service.GetById(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _service.Remove(id);
            return Ok();
        }
    }
}
