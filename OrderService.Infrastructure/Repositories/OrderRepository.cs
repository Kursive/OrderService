using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Application.Interfaces;
using OrderService.Domain.Orders;
using OrderService.Infrastructure.Persistence;


namespace OrderService.Infrastructure.Repositories
{
    public  class OrderRepository :GenericRepository<Order>,IOrderRepository
    {
    private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext) :base(dbContext)
        {

            _dbContext = dbContext;
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
