using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyFilters;
using System.Threading.Tasks;

namespace SGP.Contract.Service.PatrimonyContract.Repositories
{
    public interface ICategoriaRepository : IGenericRepository<CategoriaDoItem, CategoriaFilter>
    {
        Task<CategoriaDoItem> GetCategoriaEquipamentos(long id);
    }
}
