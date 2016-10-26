using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaladApi.Models;
using SaladApi.Repositories;
using SaladApi.ViewModels;

namespace SaladApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {

        private readonly IOrderRepository _repository;

        public OrdersController(IOrderRepository repository) 
        { 
            _repository = repository;
        }

        // GET api/orders
        [HttpGet]
        public IActionResult Get()
        {
            var orders = _repository.GetAllOrders();
            return Ok(orders);
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try 
            {
                var order = _repository.GetOrder(id);
                return Ok(order);
            } 
            catch (InvalidOperationException) 
            {
                return BadRequest("Order doesn't exist");
            }
        }

        // POST api/orders
        [HttpPost]
        public IActionResult Post([FromBody] OrderViewModel orderVm)
        {
            if (ModelState.IsValid) {
                var order = Mapper.Map<Order>(orderVm);
                try 
                {
                    var newOrder = _repository.AddOrder(order, orderVm.SaladId, orderVm.DrinkId, orderVm.UserId);
                    return Created($"api/order/{order.Id}", newOrder);
                } catch (Exception e)
                {
                    return BadRequest("Couldn't create order: " + e);
                }
            }
            return BadRequest(ModelState);
        }

        // PUT api/orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderViewModel orderVm)
        {
            if (ModelState.IsValid) {
                var order = Mapper.Map<OrderViewModel, Order>(orderVm);
                order.Id = id;
                try
                {
                    var updatedOrder = _repository.UpdateOrder(order, orderVm.SaladId, orderVm.DrinkId, orderVm.UserId);
                    return Ok(order);
                }
                catch (Exception e)
                {
                    return BadRequest("Couldn't update order: " + e);
                }   
             }
             return BadRequest(ModelState);
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.RemoveOrder(id);
                return Ok("Order was deleted");    
            }
            catch (System.Exception)
            {
              return BadRequest($"Order with Id: {id} was not found");  
            }
        }
    }
}
