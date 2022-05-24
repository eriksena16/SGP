using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyFilters;
using System.Threading.Tasks;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public class CategoriaRepository : GenericRepository<CategoriaDoItem, CategoriaFilter>, ICategoriaRepository
    {
        public CategoriaRepository(SGPContext context) : base(context) { }

        public new async Task<QueryResult<CategoriaDoItem>> Get(CategoriaFilter filter)
        {
            var query = Db.Categoria
                .AsQueryable();

            return await Get(query, filter);
        }


        public async Task<CategoriaDoItem> GetCategoriaEquipamentos(long id)
        {
            return await Db.Categoria.Include(c => c.Equipamentos).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
