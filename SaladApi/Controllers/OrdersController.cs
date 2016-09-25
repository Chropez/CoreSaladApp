using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaladApi.Models;
using SaladApi.Repository;
using SaladApi.ViewModels;

namespace SaladApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly SaladApiDbContext _context;

        public OrdersController(SaladApiDbContext context) 
        {
            _context = context;
        }

        // GET api/orders
        [HttpGet]
        public IActionResult Get()
        {
            var orders = _context.Orders
                            .Include(o => o.Salad)
                            .Include(o => o.User)
                            .Include(o => o.Drink).ToList() ;
            return Ok(orders);
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _context.Orders
                .Include(o => o.Salad)
                .Include(o => o.User)
                .Include(o => o.Drink)
                .FirstOrDefault(o => o.Id == id);

            if (order == null) 
            {
                return BadRequest("Order doesn't exist");
            }
                            
            return Ok(order);
        }

        // POST api/orders
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (ModelState.IsValid) {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return Created($"api/order/{order.Id}", order);
            }
            return BadRequest(ModelState);
        }
        
        // PUT api/orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderViewModel updatedOrder)
        {
            if (ModelState.IsValid) {
                var order = _context.Orders.Single(o => o.Id == id);
                
                Mapper.Map<OrderViewModel, Order>(updatedOrder, order);
                
                //  order.Drink = updatedOrder.Drink;
                //  order.Salad = updatedOrder.Salad;
                //  order.User = updatedOrder.User;
                 order.Delivered = updatedOrder.Delivered;

                 _context.SaveChanges();
                 return Ok(order);
             }
             return BadRequest(ModelState);
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(s => s.Id == id);
            if(order != null) {
                _context.Remove(order);
                _context.SaveChanges();
                return Ok("Order deleted");
            }
                        
            return BadRequest($"Order with Id: {id} was not found");
        }
    }
}
