using BloodManagement.Data.Interface;
using BloodManagement.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace BloodManagement.Data.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task CreateAsync(List<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }
        public Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;

        }
        public void DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {

            IQueryable<T> query = _dbSet;

            query = query.Where(filter);
            return query.FirstOrDefault();
        }
        public async Task<bool> IsExistsAsync(Expression<Func<T, bool>>? expression = null)
        {
            IQueryable<T> query = _dbSet;
            return await query.AnyAsync(expression);
        }
        public async Task DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entitiesToDelete = await _dbSet.Where(expression).ToListAsync();
            _dbSet.RemoveRange(entitiesToDelete);
            await _context.SaveChangesAsync();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        List<string>? includes = null)
        {
            IQueryable<T> query = _dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.AsNoTracking();
        }


    }
}
