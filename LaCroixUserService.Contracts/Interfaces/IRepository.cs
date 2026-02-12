namespace LaCroixUserService.Contracts.Interfaces;

public interface IRepository<T>
{
    Task<T?> Add(T entity);
    Task<T?> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T?> Update(T entity);
    Task Delete(int id);
}
