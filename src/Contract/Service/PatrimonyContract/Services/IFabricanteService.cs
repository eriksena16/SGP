using SGP.Model.Entity.ViewModels;
using SGP.Patrimony.Repository.PatrimonyFilters;

namespace SGP.Contract.Service.PatrimonyContract
{
    public interface IFabricanteService : IGenericService<FabricanteViewModel, FabricanteFilter>
    {
    }
}
