using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : IBaseEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> FindByIdAsync(params object[] keys);
        Task<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
