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
            List<CategoriaDoItem> ItemCategory = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().GetAll();
            
            return View(ItemCategory);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ItemCategory = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Details(id);
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
        public async Task<IActionResult> Create(CategoriaDoItem itemCategory)
        {
            if (ModelState.IsValid)
            {
                CategoriaDoItem ItemCategory = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Create(itemCategory);
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

            CategoriaDoItem itemCategory = await GatewayServiceProvider.Get<ICategoriaDoItemService>().GetUpdate(id.Value);

            if (itemCategory == null)
            {
                return NotFound();
            }
            return View(itemCategory);
        }

        
        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriaDoItem itemCategory)
        {
            if (id != itemCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CategoriaDoItem ItemCategory = await GatewayServiceProvider.Get<ICategoriaDoItemService>().Update(id, itemCategory);
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

            var ItemCategory = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Delete(id);
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
            var ItemCategory = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

       private async Task< bool> Exists(int id)
        {
            var exists = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Exists(id);
            return exists;
        }
    }
}
