using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Contract.Service.PatrimonyContract
{
    public interface IGenericService<T>
    {
        Task<List<T>> GetAll();
        Task<T> Details(long? id);
        Task<T> Create(T obj);
        Task<T> GetUpdate(long id);
        Task<T> Update(long id, T obj);
        Task<T> Delete(long? id);
        Task<T> DeleteConfirmed(long id);
        Task<bool> Exists(long id);

        //Task<TReturn> Create<TReturn>(T obj);
    }
}
