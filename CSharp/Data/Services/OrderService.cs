using CSharp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    CustomerName = "test1",
                    
                },
                new Order()
                {
                    Id = 2,
                    CustomerName = "test2",
                    
                },
                new Order()
                {
                    Id = 3,
                    CustomerName = "test3",
                    
                },
                new Order()
                {
                    Id = 4,
                    CustomerName = "test2",

                }
            };

        }
    
        //Get by Id
        public Order GetById(int id) => _orders.Where(a => a.Id == id).FirstOrDefault();

        // Cancel order
        public void Remove(int id)
        {
            var existing = _orders.First(a => a.Id == id);
            _orders.Remove(existing);
        }

        // Get all
        public List<Order> GetOrders()
        {
            return _orders;
        }

        // Add new order
        public Order Add(Order newOrder)
        {
            _orders.Add(newOrder);
            return newOrder;
        }
    }
}
