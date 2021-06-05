using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class ItemCategoryServices :  IItemCategoryService
    {
        private readonly SGPContext context;
        public ItemCategoryServices(SGPContext context) => this.context = context;

        public async Task<ItemCategory> Create(ItemCategory obj)
        {
            ItemCategory itemCategory = new ItemCategory();
            context.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<ItemCategory> Delete(int? id)
        {
            ItemCategory ItemCategory = await context.ItemCategory
               .FirstOrDefaultAsync(m => m.CategoryId == id);

            return ItemCategory;
        }

        public async Task<ItemCategory> DeleteConfirmed(int id)
        {
            ItemCategory itemCategory = await context.ItemCategory.FindAsync(id);
            context.ItemCategory.Remove(itemCategory);
            await context.SaveChangesAsync();

            return itemCategory;
        }

        public async Task<ItemCategory> Details(int? id)
        {
            ItemCategory ItemCategory = await context.ItemCategory
               .FirstOrDefaultAsync(m => m.CategoryId == id);

            return ItemCategory;

        }

        public async Task<List<ItemCategory>> GetAll()
        {
            List<ItemCategory> ItemCategory = await context.ItemCategory.ToListAsync();

            return ItemCategory;
        }

        public Task<ItemCategory> GetId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemCategory> Update(int id, ItemCategory obj)
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

       /* public Task<ItemCategory>  EntityExists(int id)
        {
            return context.ItemCategory.Any(e => e.CategoryId == id);
        }*/
    }
}
