using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class ItemCategoryService :  IItemCategoryService
    {
        private readonly SGPContext context;
        public ItemCategoryService(SGPContext context) => this.context = context;

        public async Task<ItemCategory> Create(ItemCategory obj)
        {
            ItemCategory itemCategory = new ItemCategory();
            context.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<ItemCategory> Delete(int? id)
        {
            ItemCategory ItemCategory = new ItemCategory();

            return await this.Details(ItemCategory.Id);
        }

        public async Task<ItemCategory> DeleteConfirmed(int id)
        {
            ItemCategory itemCategory = await context.ItemCategory.FindAsync(id);
            context.ItemCategory.Remove(itemCategory);
            await context.SaveChangesAsync();

            return itemCategory;
        }

        public async Task<ItemCategory> Details(long? id)
        {
            ItemCategory ItemCategory = await context.ItemCategory
               .FirstOrDefaultAsync(m => m.Id == id);

            return ItemCategory;

        }

        public async Task<List<ItemCategory>> GetAll()
        {
            List<ItemCategory> ItemCategory = await context.ItemCategory.ToListAsync();

            return ItemCategory;
        }

        public async Task<ItemCategory> Update(long id, ItemCategory obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        } 
        public async Task<ItemCategory> GetUpdate(int id)
        {
            var itemCategory = await context.ItemCategory.FindAsync(id);

            return itemCategory;
        }

        public async Task< bool> Exists(long id)
        {
            return await Task.FromResult( context.ItemCategory.Any(e => e.Id == id));
        }
    }
}
