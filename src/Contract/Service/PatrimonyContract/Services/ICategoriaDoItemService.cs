
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;
using SGP.Patrimony.Repository.PatrimonyFilters;
using System.Threading.Tasks;

namespace SGP.Contract.Service.PatrimonyContract
{
    public interface ICategoriaDoItemService : IGenericService<CategoriaDoItemViewModel, CategoriaFilter>
    {
        Task<CategoriaDoItem> GetCategoriaEquipamentos(long id);
    }
}
