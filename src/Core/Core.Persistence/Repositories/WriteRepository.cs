using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.Persistence.Repositories;

public class WriteRepository<T, TContext> : IWriteRepository<T> 
    where T : Entity
    where TContext : DbContext
{
    protected TContext Context { get; }
    public WriteRepository(TContext context)
    {
        Context = context;
    }
    public DbSet<T> Table => Context.Set<T>();
    public IQueryable<T> Query() => Table;

    public async Task<T> AddAsync(T entity, bool withSave = true)
    {
        EntityEntry<T> entry = await Table.AddAsync(entity);
        if (withSave)
        {
            await SaveAsync();
        }
        return entry.Entity;
    }

    public async Task<List<T>> AddRangeAsync(List<T> entities, bool withSave)
    {
        await Table.AddRangeAsync(entities);
        if (withSave)
        {
            await SaveAsync();
        }
        return entities;
    }
    
    public async Task<T> Remove(T entity, bool withSave = true)
    {
        EntityEntry<T> entry = Table.Remove(entity);
        if (withSave)
        {
            await SaveAsync();
        }
        return entry.Entity;
    }

    public async Task<List<T>> RemoveRange(List<T> entities, bool withSave = true)
    {
        Table.RemoveRange(entities);
        if (withSave)
        {
            await SaveAsync();
        }
        return entities;
    }

    public async Task<T> RemoveAsync(string id, bool withSave)
    {
        T entity = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        return await Remove(entity, withSave);
    }

    public async Task<T> Update(T entity, bool withSave = true)
    {
        EntityEntry<T> entry = Table.Update(entity);
        if (withSave)
        {
            await SaveAsync();
        }
        return entry.Entity;
    }

    public async Task<int> SaveAsync()
        => await Context.SaveChangesAsync();
}