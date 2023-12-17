using Domain.Common;

namespace Application.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> Add(T entity);
    Task Delete(T entity);
    Task<bool> Exists(Guid id);
    Task<T?> Get(Guid id);
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Update(T entity);
}