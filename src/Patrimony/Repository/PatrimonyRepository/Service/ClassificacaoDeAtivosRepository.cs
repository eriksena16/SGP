using LuxERP.Services.SGP.Patrimony.Repository.PatrimonyFilters;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public class ClassificacaoDeAtivosRepository : GenericRepository<ClassificacaoDeAtivos, ClassificacaoDeAtivosFilter>, IClassificacaoDeAtivosRepository
    {
        public ClassificacaoDeAtivosRepository(SGPContext context) : base(context) { }
    }
}
