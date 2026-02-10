using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Orders;

namespace OrderService.Infrastructure.Persistence
{
    public  class AppDbContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
