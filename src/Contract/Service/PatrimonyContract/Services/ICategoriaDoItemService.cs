
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;
using System.Threading.Tasks;

namespace SGP.Contract.Service.PatrimonyContract
{
    public interface ICategoriaDoItemService : IGenericService<CategoriaDoItemViewModel>
    {
        Task<CategoriaDoItem> GetCategoriaEquipamentos(long id);
    }
}
