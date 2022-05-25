using LuxERP.Services.SGP.Patrimony.Repository.PatrimonyFilters;
using SGP.Model.Entity;

namespace SGP.Contract.Service.PatrimonyContract.Repositories
{
    public interface ISetorRepository : IGenericRepository<Setor, SetorFilter>
    {
    }
}
