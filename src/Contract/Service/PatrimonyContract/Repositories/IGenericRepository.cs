using SGP.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SGP.Contract.Service.PatrimonyContract.Repositories
{
    public interface IGenericRepository<TEntity, G> : IDisposable where TEntity : BaseEntity
    {
        Task Create(TEntity obj);
        Task<TEntity> Get(long id);
        Task Update( TEntity obj);
        Task Delete(long id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<QueryResult<TEntity>> Get(G filter);
        Task<int> SaveChanges();
    }
}
