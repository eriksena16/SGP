using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyFilters;
using System.Threading.Tasks;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public class SetorRepository : GenericRepository<Setor, SetorFilter>, ISetorRepository
    {
        public SetorRepository(SGPContext context) : base(context) { }

        public new async Task<QueryResult<Setor>> Get(SetorFilter filter)
        {
            var query = Db.Setor
                .AsQueryable();

            return await Get(query, filter);
        }
    }
}

