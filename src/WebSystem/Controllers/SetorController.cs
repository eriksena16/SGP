using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGP.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Controllers
{
    public class SetorController : ApplicationController
    {
        public async Task<IActionResult> Index()
        {
            List<Setor> setor = await this.GatewayServiceProvider.Get<ISetorService>().GetAll();

            return View(setor);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await this.GatewayServiceProvider.Get<ISetorService>().Details(id);
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
        public async Task<IActionResult> Create(Setor setor)
        {
            if (ModelState.IsValid)
            {
                Setor Sector = await this.GatewayServiceProvider.Get<ISetorService>().Create(setor);
                return RedirectToAction(nameof(Index));
            }
            return View(setor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Setor setor = await GatewayServiceProvider.Get<ISetorService>().GetUpdate(id.Value);

            if (setor == null)
            {
                return NotFound();
            }
            return View(setor);
        }


        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Setor setor)
        {
            if (id != setor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Setor Sector = await GatewayServiceProvider.Get<ISetorService>().Update(id, setor);
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!await Exists(setor.Id))
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
            return View(setor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await this.GatewayServiceProvider.Get<ISetorService>().Delete(id);
            if (setor == null)
            {
                return NotFound();
            }

            return View(setor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var setor = await this.GatewayServiceProvider.Get<ISetorService>().DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> Exists(long id)
        {
            var exists = await this.GatewayServiceProvider.Get<ISetorService>().Exists(id);
            return exists;
        }
    }
}
