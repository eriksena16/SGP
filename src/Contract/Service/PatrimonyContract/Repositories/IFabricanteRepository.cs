using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyFilters;

namespace SGP.Contract.Service.PatrimonyContract.Repositories
{
    public interface IFabricanteRepository : IGenericRepository<Fabricante, FabricanteFilter>
    {
    }
}
