
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyFilters;
using System.Threading.Tasks;

namespace SGP.Contract.Service.PatrimonyContract
{
    public interface ICategoriaDoItemService : IGenericService<CategoriaDoItemDTO, CategoriaFilter>
    {
        Task<CategoriaDoItem> GetCategoriaEquipamentos(long id);
    }
}
