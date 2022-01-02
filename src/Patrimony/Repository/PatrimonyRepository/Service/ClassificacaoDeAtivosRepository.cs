using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public class ClassificacaoDeAtivosRepository : GenericRepository<ClassificacaoDeAtivos>, IClassificacaoDeAtivosRepository
    {
        public ClassificacaoDeAtivosRepository(DbContext context) : base(context) { }
    }
}
