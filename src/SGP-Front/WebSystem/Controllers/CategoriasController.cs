using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGP.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Controllers
{
    public class CategoriasController : ApplicationController
    {

        public async Task<IActionResult> Index()
        {
            var categoriaDoItem = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Get();

            return View(categoriaDoItem);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var categoriaDoItem = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Get(id.Value);
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
        public async Task<IActionResult> Create(CategoriaDoItemViewModel categoriaDoItem)
        {
            if (ModelState.IsValid)
            {
                var CategoriaDoItem = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Add(categoriaDoItem);
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

            var categoriaDoItem = await GatewayServiceProvider.Get<ICategoriaDoItemService>().Get(id.Value);

            if (categoriaDoItem == null)
            {
                return NotFound();
            }
            return View(categoriaDoItem);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, CategoriaDoItemViewModel categoriaDoItem)
        {
            if (id != categoriaDoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ItemCategory = await GatewayServiceProvider.Get<ICategoriaDoItemService>().Update(categoriaDoItem);
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDoItem);
        }
        public async Task<IActionResult> Delete(long id)
        {

            var categoria = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().GetCategoriaEquipamentos(id);

            if (categoria is null)
            {
                return NotFound();
            }

            await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Get(id);

            if (categoria is null)
            {
                return NotFound();
            }

            await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().DeleteOld(categoria);

            return RedirectToAction(nameof(Index));
        }

    }
}
