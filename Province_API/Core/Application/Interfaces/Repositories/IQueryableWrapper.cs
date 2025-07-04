namespace Province_API.Core.Application.Interfaces.Repositories
{
    public interface IQueryableWrapper<T> where T : class
    {
        Task<List<T>> ToListAsync();

        Task<T> FirstOrDefaultAsync();

        Task<int> CountAsync();
    }
}
