using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Model
{
    public class OrdersContext: DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
