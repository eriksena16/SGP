using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public class FabricanteRepository : GenericRepository<Fabricante>, IFabricanteRepository
    {
        public FabricanteRepository(DbContext context) : base(context) { }
    }
}
