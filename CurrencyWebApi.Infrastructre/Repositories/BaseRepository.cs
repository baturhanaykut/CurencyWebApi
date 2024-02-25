using CurrencyWebApi.Domain.Repositories;
using CurrencyWebApi.Infrastructre.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CurrencyWebApi.Infrastructre.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        protected DbSet<TEntity> _table;

        
        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _table = _applicationDbContext.Set<TEntity>();
        }

        public async Task<bool> Add(TEntity entity)
        {
            await _table.AddAsync(entity);
            return await Save() > 0;
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

        public async Task<bool> Delete(TEntity entity)
        {
            return await Save() > 0;
        }

        public virtual async Task<TEntity> GetDefault(Expression<Func<TEntity, bool>> expression)
        {
            return await _table.FirstOrDefaultAsync(expression);
        }

        public async Task<List<TEntity>> GetDefaults(Expression<Func<TEntity, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(
                    Expression<Func<TEntity, TResult>> select,
                    Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>,
                    IOrderedQueryable<TEntity>> orderby = null, Func<IQueryable<TEntity>,
                    IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _table;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderby != null)
            {
                return await orderby(query).Select(select).FirstOrDefaultAsync();
            }
            else
            {
                return await query.Select(select).FirstOrDefaultAsync();
            }
        }

        public async Task<List<TResult>> GetFilteredList<TResult>(
                    Expression<Func<TEntity, TResult>> select,
                    Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>,
                    IOrderedQueryable<TEntity>> orderby = null, Func<IQueryable<TEntity>,
                    IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _table;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderby != null)
            {
                return await orderby(query).Select(select).ToListAsync();
            }
            else
            {
                return await query.Select(select).ToListAsync();
            }
        }

        public async Task<int> Save()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(TEntity entity)
        {
            _applicationDbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            return await Save() > 0;
        }

    }
}
