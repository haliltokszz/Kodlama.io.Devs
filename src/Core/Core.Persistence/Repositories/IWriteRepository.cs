namespace Core.Persistence.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : Entity
{
    Task<T> AddAsync(T entity, bool withSave = true);
    Task<List<T>> AddRangeAsync(List<T> entities, bool withSave = true);
    Task<T> Remove(T entity, bool withSave = true);
    Task<List<T>> RemoveRange(List<T> entities, bool withSave = true);
    Task<T> RemoveAsync(string id, bool withSave = true);
    Task<T> Update(T entity, bool withSave = true);
    Task<int> SaveAsync();
}