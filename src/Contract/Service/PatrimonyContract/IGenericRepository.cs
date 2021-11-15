using SGP.Model.Entity;
using SGPGeneric.Entities;
using System.Threading.Tasks;

namespace SGP.Contract.Service.PatrimonyContract
{
    public interface IGenericRepository<T, G> where T : GenericEntity, new()
    {
        Task<T> Get(long id, G filter);
        Task<QueryResult<T>> Get(G filter);
        Task<T> Get(long id);
        void Create(T obj);
        void Update( T obj);
        void Delete(T obj);

    }
}
