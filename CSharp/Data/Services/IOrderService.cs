using CSharp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Data.Services
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        Order Add(Order newOrder);
        Order GetById(int id);
        void Remove(int id);
    }
}
