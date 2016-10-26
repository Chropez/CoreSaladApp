using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaladApi.Models;
using SaladApi.Repositories;
using SaladApi.ViewModels;

namespace SaladApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly SaladApiDbContext _context;
        private readonly IOrderRepository _orderRepository ;

        public UsersController(SaladApiDbContext context, IOrderRepository orderRepository) 
        {
            _context = context;
            _orderRepository = orderRepository;
        }

        // GET api/Users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Users.ToList());
        }

        // GET api/Users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.Users.FirstOrDefault(s => s.Id == id));
        }

        // POST api/Users
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid) {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Created($"api/user/{user.Id}", user);
            }
            return BadRequest(ModelState);
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Drink updatedUser)
        {
             if (ModelState.IsValid) {
                 var user = _context.Users.First(s => s.Id == id);
                 user.Name = updatedUser.Name;
                 _context.SaveChanges();
                 return Ok(user);
             }
             return BadRequest(ModelState);
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(s => s.Id == id);
            if(user != null) {
                _context.Remove(user);
                _context.SaveChanges();
                return Ok("User deleted");
            }
                        
            return BadRequest($"User with Id: {id} was not found");
        }

        // Check if a person has ordered salad x
        [HttpGet("{id}/salads/{saladId}")]
        public IActionResult HasSalad(int id, int saladId, [FromQuery] bool? delivered)
        {
            try 
            {
                var orders = _context.Orders.Where(o => o.User.Id == id && o.Salad.Id == saladId);
                if (delivered != null)
                {
                    orders = orders.Where(o => o.Delivered == delivered);
                }

                if (orders.Any())
                    return Ok();
                else
                    return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }

        // Change salad for user
        [HttpPut("{id}/orders/{orderId}")]
        public IActionResult ChangeOrder(int id, int orderId, [FromBody] OrderViewModel vm)
        {
            vm.UserId = id;
            if (ModelState.IsValid)
            {
                try 
                {
                    var order = Mapper.Map<OrderViewModel, Order>(vm);
                    order.Id = id;

                    var changedOrder = _orderRepository.UpdateOrderForUser(order, vm.SaladId, vm.DrinkId, vm.UserId);
                    return Ok(changedOrder);
                }
                catch (Exception e)
                {
                    return BadRequest($"Couldn't update order: {e}");
                }
            }

            return BadRequest(ModelState);


        }
    }
}
