namespace LaCroix.UserService.Contracts.Interfaces;

public interface IRepository<T>
{
    Task<T?> Add(T entity);
    Task<T?> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task<T?> Update(T entity);
    Task Delete(Guid id);
}
