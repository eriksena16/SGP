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
        private readonly SGPContext _context;
        public CategoriaDoItemService(SGPContext context) => this._context = context;

        public async Task<CategoriaDoItem> Create(CategoriaDoItem obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<CategoriaDoItem> Delete(long? id)
        {
            return await this.Details(id);
        }

        public async Task<CategoriaDoItem> DeleteConfirmed(long id)
        {
            CategoriaDoItem itemCategory = await _context.Categoria.FindAsync(id);
            _context.Categoria.Remove(itemCategory);
            await _context.SaveChangesAsync();

            return itemCategory;
        }

        public async Task<CategoriaDoItem> Details(long? id)
        {
            CategoriaDoItem ItemCategory = await _context.Categoria
               .FirstOrDefaultAsync(m => m.Id == id);

            return ItemCategory;

        }

        public async Task<List<CategoriaDoItem>> GetAll()
        {
            List<CategoriaDoItem> ItemCategory = await _context.Categoria.ToListAsync();

            return ItemCategory;
        }

        public async Task<CategoriaDoItem> Update(long id, CategoriaDoItem obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();

            return obj;
        } 
        public async Task<CategoriaDoItem> GetUpdate(long id)
        {
            var itemCategory = await _context.Categoria.FindAsync(id);

            return itemCategory;
        }

        public async Task< bool> Exists(long id)
        {
            return await Task.FromResult( _context.Categoria.Any(e => e.Id == id));
        }
    }
}
