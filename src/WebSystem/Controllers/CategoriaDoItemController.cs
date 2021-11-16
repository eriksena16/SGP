using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGP.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Controllers
{
    public class CategoriaDoItemController : ApplicationController
    {

        public async Task<IActionResult> Index()
        {
            List<CategoriaDoItem> categoriaDoItem = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().GetAll();
            
            return View(categoriaDoItem);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaDoItem = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Get(id);
            if (categoriaDoItem == null)
            {
                return NotFound();
            }

            return View(categoriaDoItem);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaDoItem categoriaDoItem)
        {
            if (ModelState.IsValid)
            {
                CategoriaDoItem CategoriaDoItem = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Create(categoriaDoItem);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDoItem);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoriaDoItem categoriaDoItem = await GatewayServiceProvider.Get<ICategoriaDoItemService>().GetUpdate(id.Value);

            if (categoriaDoItem == null)
            {
                return NotFound();
            }
            return View(categoriaDoItem);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, CategoriaDoItem categoriaDoItem)
        {
            if (id != categoriaDoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CategoriaDoItem ItemCategory = await GatewayServiceProvider.Get<ICategoriaDoItemService>().Update(id, categoriaDoItem);
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!await Exists(categoriaDoItem.Id))
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
            return View(categoriaDoItem);
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

       private async Task< bool> Exists(long id)
        {
            var exists = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Exists(id);
            return exists;
        }
    }
}
