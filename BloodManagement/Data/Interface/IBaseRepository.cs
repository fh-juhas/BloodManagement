using System.Linq.Expressions;
using System.Collections;
namespace BloodManagement.Data.Interface
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
       // Task CreateAsync(List<T> entity);
        Task UpdateAsync(T entity);
        //void DeleteAsync(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> expression);
        Task<bool> IsExistsAsync(Expression<Func<T, bool>>? expression = null);
        IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        List<string>? includes = null);
        Task<T> GetByIdAsync(string Id);
    }
}
