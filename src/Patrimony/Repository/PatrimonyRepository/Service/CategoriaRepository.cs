using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using System.Threading.Tasks;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public class CategoriaRepository : GenericRepository<CategoriaDoItem>, ICategoriaRepository
    {
        public CategoriaRepository(SGPContext context) : base(context) {}


        public async Task<CategoriaDoItem> GetCategoriaEquipamentos(long id)
        {
            return await Db.Categoria.Include(c=> c.Equipamentos).AsNoTracking().FirstOrDefaultAsync(c=> c.Id == id);
        }
    }
}
