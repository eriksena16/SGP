using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGP.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Controllers
{
    public class CategoriasController : ApplicationController
    {

        public async Task<IActionResult> Index()
        {
            List<CategoriaDoItem> categoriaDoItem = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Get();

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

            CategoriaDoItem categoriaDoItem = await GatewayServiceProvider.Get<ICategoriaDoItemService>().Get(id.Value);

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
                    CategoriaDoItem ItemCategory = await GatewayServiceProvider.Get<ICategoriaDoItemService>().Update(categoriaDoItem);
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDoItem);
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

            await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Delete(categoria);

            return RedirectToAction(nameof(Index));
        }

    }
}
