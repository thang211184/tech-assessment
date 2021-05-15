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
                    IsCanceled = false,
                },
                new Order()
                {
                    Id = 2,
                    CustomerName = "test2",
                    IsCanceled = false,
                },
                new Order()
                {
                    Id = 3,
                    CustomerName = "test3",
                    IsCanceled = false,
                }
            };

        }
    

        public Order add(Order newOrder)
        {
            _orders.Add(newOrder);
            return newOrder;
        }

        public Order GetById(int id) => _orders.Where(a => a.Id == id).FirstOrDefault();

        public void Remove(int id)
        {
            var existing = _orders.First(a => a.Id == id);
            _orders.Remove(existing);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orders;
        }

        public Order Add(Order newOrder)
        {
            throw new NotImplementedException();
        }
    }
}
