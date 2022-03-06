namespace Api.Data;

public interface IAsyncRepository<T>
{
    Task<T> Get(int id);
    IAsyncEnumerable<T> GetAll();
    IQueryable<T> CustomQuery();
    Task<T> Create(T entity);
    Task<T> Update(int id, T entity);
    Task Delete(int id);
}