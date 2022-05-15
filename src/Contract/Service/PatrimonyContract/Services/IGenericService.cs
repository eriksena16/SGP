using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Contract.Service.PatrimonyContract
{
    public interface IGenericService<TEntity>
    {
        Task<TEntity> Add(TEntity obj);
        Task<List<TEntity>> Get();
        Task<TEntity> Get(long id);
        Task<TEntity> Update(TEntity obj);
        Task DeleteOld(TEntity obj);
        Task Delete(long id);
        //Task<bool> Exists(long id);

        //Task<TReturn> Create<TReturn>(T obj);
    }
}
