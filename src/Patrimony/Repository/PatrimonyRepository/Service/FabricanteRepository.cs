using LuxERP.Services.SGP.Patrimony.Repository.PatrimonyFilters;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public class FabricanteRepository : GenericRepository<Fabricante, FabricanteFilter>, IFabricanteRepository
    {
        public FabricanteRepository(SGPContext context) : base(context) { }
    }
}
