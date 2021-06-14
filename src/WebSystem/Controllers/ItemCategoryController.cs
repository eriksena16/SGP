using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGP.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Controllers
{
    public class ItemCategoryController : ApplicationController
    {

        public async Task<IActionResult> Index()
        {
            List<ItemCategory> ItemCategory = await this.GatewayServiceProvider.Get<IItemCategoryService>().GetAll();
            
            return View(ItemCategory);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ItemCategory = await this.GatewayServiceProvider.Get<IItemCategoryService>().Details(id);
            if (ItemCategory == null)
            {
                return NotFound();
            }

            return View(ItemCategory);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemCategory itemCategory)
        {
            if (ModelState.IsValid)
            {
                ItemCategory ItemCategory = await this.GatewayServiceProvider.Get<IItemCategoryService>().Create(itemCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(itemCategory);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemCategory itemCategory = await GatewayServiceProvider.Get<IItemCategoryService>().GetUpdate(id.Value);

            if (itemCategory == null)
            {
                return NotFound();
            }
            return View(itemCategory);
        }

        
        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ItemCategory itemCategory)
        {
            if (id != itemCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ItemCategory ItemCategory = await GatewayServiceProvider.Get<IItemCategoryService>().Update(id, itemCategory);
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!await Exists(itemCategory.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(itemCategory);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ItemCategory = await this.GatewayServiceProvider.Get<IItemCategoryService>().Delete(id);
            if (ItemCategory == null)
            {
                return NotFound();
            }

            return View(ItemCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ItemCategory = await this.GatewayServiceProvider.Get<IItemCategoryService>().DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

       private async Task< bool> Exists(int id)
        {
            var exists = await this.GatewayServiceProvider.Get<IItemCategoryService>().Exists(id);
            return exists;
        }
    }
}
