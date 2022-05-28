using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyFilters;
using System.Threading.Tasks;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public class FabricanteRepository : GenericRepository<Fabricante, FabricanteFilter>, IFabricanteRepository
    {
        public FabricanteRepository(SGPContext context) : base(context) { }

        public new async Task<QueryResult<Fabricante>> Get(FabricanteFilter filter)
        {
            var query = Db.Fabricante
                .AsQueryable();

            return await Get(query, filter);
        }
    }
}
