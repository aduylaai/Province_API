using Microsoft.EntityFrameworkCore;
using Province_API.Core.Application.Interfaces.Repositories;

namespace Province_API.Infrastructure.Repositories
{
    public class QueryableWrapper<T> : IQueryableWrapper<T> where T : class
    {
        private readonly IQueryable<T> _queryable;

        public QueryableWrapper(IQueryable<T> queryable)
        {
            _queryable = queryable;
        }

        public async Task<List<T>> ToListAsync()
        {
            return await _queryable.ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync()
        {
            return await _queryable.FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _queryable.CountAsync();
        }
    }
}
