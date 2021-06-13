using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Contract.Service.PatrimonyContract
{
    public interface IGenericService<T>
    {
        Task<List<T>> GetAll();
        Task<T> Details(int? id);
        Task<T> Create(T obj);
        Task<T> GetUpdate(int id);
        Task<T> Update(int id, T obj);
        Task<T> Delete(int? id);
        Task<T> DeleteConfirmed(int id);
        Task<bool> Exists(int id);


    }
}
