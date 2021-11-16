using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public class CategoriaRepository : GenericRepository<CategoriaDoItem>, ICategoriaRepositoy
    {
        public CategoriaRepository(DbContext context) : base(context) {}
    }
}
