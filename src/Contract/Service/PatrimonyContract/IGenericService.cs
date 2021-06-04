using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Contract.GenericContract
{
    public interface IGenericService<T>
    {
        Task<List<T>> GetAll();
        Task<IEnumerable<T>> GetId(int id);
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<T> Delete(int? id);


        //Task<T> DeleteConfirmed(int id);
        //Task<IEnumerable<T>> Details(int? id);

    }
}
