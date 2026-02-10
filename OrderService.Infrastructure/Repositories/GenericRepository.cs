using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using OrderService.Infrastructure.Persistence;

namespace OrderService.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly AppDbContext _dbContext;
        public GenericRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext; 
        }
        public async Task<T> CreateOrder(T order, CancellationToken cancellationToken=default)
        {
            await _dbContext.Set<T>().AddAsync(order,cancellationToken);
            return order;
        }
        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken=default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => await _dbContext.Set<T>().FindAsync(id, cancellationToken);

        public async Task SaveChangeAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

}
