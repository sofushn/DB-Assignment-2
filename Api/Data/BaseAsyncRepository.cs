using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public abstract class BaseAsyncRepository<T> : IAsyncRepository<T> where T : class, EntityWithId
{
    protected readonly DbContext Context;
    protected readonly DbSet<T> ContextCollection;

    protected BaseAsyncRepository(DbContext dbContext, DbSet<T> contextCollection)
    {
        Context = dbContext;
        ContextCollection = contextCollection;
    }

    public Task<T> Get(int id)
        => ContextCollection.FirstAsync(x => x.Id == id);

    public IAsyncEnumerable<T> GetAll()
        => CustomQuery().AsAsyncEnumerable();

    public IQueryable<T> CustomQuery()
        => ContextCollection;

    public async Task<T> Create(T entity)
    {
        await ContextCollection.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Update(int id, T entity)
    {
        ContextCollection.Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(int id)
    {
        T entity = await ContextCollection.FirstAsync(x => x.Id == id);
        ContextCollection.Remove(entity);
        await Context.SaveChangesAsync();
    }
}
