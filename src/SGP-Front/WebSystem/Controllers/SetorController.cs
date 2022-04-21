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
    public class SetorController : ApplicationController
    {
        public async Task<IActionResult> Index()
        {
            var setor = await this.GatewayServiceProvider.Get<ISetorService>().Get();

            return View(setor);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await this.GatewayServiceProvider.Get<ISetorService>().Get(id.Value);
            if (setor == null)
            {
                return NotFound();
            }

            return View(setor);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SetorViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var setor = await this.GatewayServiceProvider.Get<ISetorService>().Add(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await GatewayServiceProvider.Get<ISetorService>().Get(id.Value);

            if (setor == null)
            {
                return NotFound();
            }
            return View(setor);
        }


        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SetorViewModel obj)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var setor = await GatewayServiceProvider.Get<ISetorService>().Update(obj);
                }
                catch (DbUpdateConcurrencyException)
                {


                }
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(long id)
        {

            var setor = await this.GatewayServiceProvider.Get<ISetorService>().Get(id);


            if (setor == null)
                return NotFound();
            else
                await this.GatewayServiceProvider.Get<ISetorService>().Delete(setor);

            return View(setor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var setor = await this.GatewayServiceProvider.Get<ISetorService>().Get(id);

            if (setor != null)
                await this.GatewayServiceProvider.Get<ISetorService>().Delete(setor);

            return RedirectToAction(nameof(Index));
        }

    }
}
