using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Vendr.Domain.Entities;

namespace Vendr.Domain.Interfaces
{
    public interface IRepositoryAsync<TEntity> : IDisposable where TEntity:BaseEntity
    {
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter = null, string[] includes = null);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, string[] includes = null);        
        Task<TEntity> GetByIdAsync(int id);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);
        void Update(TEntity entity);
        Task DeleteAsync(int id);
        void Merge(TEntity persisted, TEntity current);
        Task CommitAsync();
    }
}
