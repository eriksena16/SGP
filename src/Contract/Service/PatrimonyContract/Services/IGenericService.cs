using SGP.Model.Entity;
using System.Threading.Tasks;


namespace SGP.Contract.Service.PatrimonyContract
{
    public interface IGenericService<TEntity, G>
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> Get(long id);
        Task<TEntity> Update(TEntity obj);
        Task Delete(long id);
        Task<QueryResult<TEntity>> Get(G filter);
       
    }
}
