using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Stromatolite.DAL
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {

        int Count(Expression<Func<TEntity, bool>> filter = null);

        Task<List<TEntity>> GetAsync(CancellationToken cancellationToken = default(CancellationToken),
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int skip = 0, int take = 0);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int skip = 0, int take = 0);

        TEntity Get(bool single,
            Expression<Func<TEntity, bool>> filter,
            string includeProperties = "");

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter,
            string includeProperties = "",
            CancellationToken cancellationToken = default(CancellationToken),
            bool single = true);

        TEntity GetByID(object id);

        Task<TEntity> GetByIDAsync(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void UpdateRange(IEnumerable<TEntity> entitiesToUpdate);

        void Update(TEntity entityToUpdate);
    }
}