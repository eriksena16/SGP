using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public class SetorRepository : GenericRepository<Setor>, ISetorRepository
    {
        public SetorRepository(SGPContext context) : base(context) { }
    }
}

