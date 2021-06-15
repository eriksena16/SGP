using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class CategoriaDoItemService :  ICategoriaDoItemService
    {
        private readonly SGPContext context;
        public CategoriaDoItemService(SGPContext context) => this.context = context;

        public async Task<CategoriaDoItem> Create(CategoriaDoItem obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<CategoriaDoItem> Delete(int? id)
        {
            CategoriaDoItem ItemCategory = new CategoriaDoItem();

            return await this.Details(ItemCategory.Id);
        }

        public async Task<CategoriaDoItem> DeleteConfirmed(int id)
        {
            CategoriaDoItem itemCategory = await context.Categoria.FindAsync(id);
            context.Categoria.Remove(itemCategory);
            await context.SaveChangesAsync();

            return itemCategory;
        }

        public async Task<CategoriaDoItem> Details(long? id)
        {
            CategoriaDoItem ItemCategory = await context.Categoria
               .FirstOrDefaultAsync(m => m.Id == id);

            return ItemCategory;

        }

        public async Task<List<CategoriaDoItem>> GetAll()
        {
            List<CategoriaDoItem> ItemCategory = await context.Categoria.ToListAsync();

            return ItemCategory;
        }

        public async Task<CategoriaDoItem> Update(long id, CategoriaDoItem obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        } 
        public async Task<CategoriaDoItem> GetUpdate(int id)
        {
            var itemCategory = await context.Categoria.FindAsync(id);

            return itemCategory;
        }

        public async Task< bool> Exists(long id)
        {
            return await Task.FromResult( context.Categoria.Any(e => e.Id == id));
        }
    }
}
