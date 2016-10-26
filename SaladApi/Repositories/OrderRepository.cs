using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaladApi.Models;

namespace SaladApi.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrder(int id);
        Order AddOrder(Order order, int saladId, int drinkId, int userId);        
        Order UpdateOrder(Order updatedOrder, int saladId, int drinkId, int userId);
        Order UpdateOrderForUser(Order updatedOrder, int saladId, int drinkId, int userId);

        void RemoveOrder(int orderId);        
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly SaladApiDbContext _context;
        public OrderRepository(SaladApiDbContext context)
        { 
            _context = context;
        }

        public IEnumerable<Order> GetAllOrders() 
        {
            return _context.Orders
                        .Include(o => o.Salad)
                        .Include(o => o.User)
                        .Include(o => o.Drink).ToList() ;
        }

        public Order GetOrder(int id) 
        {
            return _context.Orders
                        .Include(o => o.Salad)
                        .Include(o => o.User)
                        .Include(o => o.Drink)
                        .Single(o => o.Id == id);
        }

        public Order AddOrder(Order order, int saladId, int drinkId, int userId)
        {
            AddOrderRelations(order, saladId, drinkId, userId);
            
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public Order UpdateOrder(Order updatedOrder, int saladId, int drinkId, int userId) 
        {
            _context.Attach<Order>(updatedOrder);
                
            AddOrderRelations(updatedOrder, saladId, drinkId, userId);
            
            _context.SaveChanges();
            return updatedOrder;
        }
        public Order UpdateOrderForUser(Order updatedOrder, int saladId, int drinkId, int userId) 
        {
            // Check if the user is the owner of the order 
            var order = _context.Orders.Single(o => o.Id == updatedOrder.Id && o.User.Id == userId);
            order = Mapper.Map<Order, Order>(updatedOrder, order);
            
            return UpdateOrder(order, saladId, drinkId, userId);
        }

        public void RemoveOrder(int orderId)
        {
            var order = new Order { Id = orderId };
            _context.Attach<Order>(order);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
        

        private void AddOrderRelations(Order order, int saladId, int drinkId, int userId) 
        {
            var salad = _context.Salads.Single(s => s.Id == saladId);
            var drink = _context.Drinks.Single(s => s.Id == drinkId);
            var user = _context.Users.Single(s => s.Id == userId);

            order.Salad = salad;
            order.Drink = drink;
            order.User = user; 
        }
    }
}
