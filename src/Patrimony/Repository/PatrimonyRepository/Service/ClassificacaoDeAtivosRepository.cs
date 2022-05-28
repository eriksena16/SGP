using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyFilters;
using System.Threading.Tasks;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public class ClassificacaoDeAtivosRepository : GenericRepository<ClassificacaoDeAtivos, ClassificacaoDeAtivosFilter>, IClassificacaoDeAtivosRepository
    {
        public ClassificacaoDeAtivosRepository(SGPContext context) : base(context) { }

        public new async Task<QueryResult<ClassificacaoDeAtivos>> Get(ClassificacaoDeAtivosFilter filter)
        {
            var query = Db.Classificacao
                .AsQueryable();

            return await Get(query, filter);
        }
    }
}
