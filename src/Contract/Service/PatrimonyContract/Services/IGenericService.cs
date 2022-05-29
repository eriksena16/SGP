using SGP.Model.Entity;
using System.Dynamic;
using System.Threading.Tasks;


namespace SGP.Contract.Service.PatrimonyContract
{
    public interface IGenericService<TEntity, G> where TEntity : BaseEntity, new()
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> Get(long id);
        TEntity GetAsnotrack(long id);
        Task Patch(long id, ExpandoObject patch);
        Task Delete(long id);
        Task<QueryResult<TEntity>> Get(G filter);

    }
}
