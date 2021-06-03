using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Contract.GenericContract
{
    public interface IGenericService<T>
    {
        Task<List<T>> Index();
        Task<T> GetId(int id);
        Task<T> Details(int id);
        Task<T> Create();
        Task<T> Update();
        Task<T> Delete();
    }
}
