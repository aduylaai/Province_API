using Microsoft.EntityFrameworkCore;
using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Data;

namespace Province_API.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
