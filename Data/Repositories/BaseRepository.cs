using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly DatabaseContex _context;
        private DbSet<TEntity> _entities;

        public BaseRepository(DatabaseContex context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable();
        }
        public virtual async Task<TEntity> FindByIdAsync(params object[] keys)
        {
            return await _entities.FindAsync(keys);
        }
        public virtual async Task<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate)
        {

            return await _entities.FirstOrDefaultAsync(predicate);
        }
        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }
        public virtual void AddRange(IEnumerable<TEntity> entity)
        {
            _entities.AddRange(entity);
        }
        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entity)
        {
            _entities.RemoveRange(entity);
        }
        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _entities.Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            lock (_context)
            {
                return _context.SaveChangesAsync().Result;
            }
        }

        
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _entities = null;
                }
                _context?.Dispose();
                _disposed = true;
            }
        }

        ~BaseRepository()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
