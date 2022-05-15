using SGP.Model.Entity;
using System.Threading.Tasks;

namespace SGP.Contract.Service.PatrimonyContract.Repositories
{
    public interface ICategoriaRepository : IGenericRepository<CategoriaDoItem>
    {
        Task<CategoriaDoItem> GetCategoriaEquipamentos(long id);
    }
}
