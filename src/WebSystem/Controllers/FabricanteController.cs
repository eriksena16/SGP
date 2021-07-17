using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGP.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Controllers
{
    public class FabricanteController : ApplicationController
    {

        public async Task<IActionResult> Index()
        {
            List<Fabricante> fabricante = await this.GatewayServiceProvider.Get<IFabricanteService>().GetAll();

            return View(fabricante);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fabricante = await this.GatewayServiceProvider.Get<IFabricanteService>().Details(id);
            if (fabricante == null)
            {
                return NotFound();
            }

            return View(fabricante);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                Fabricante fabricantes = await this.GatewayServiceProvider.Get<IFabricanteService>().Create(fabricante);
                return RedirectToAction(nameof(Index));
            }
            return View(fabricante);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fabricante fabricantes = await GatewayServiceProvider.Get<IFabricanteService>().GetUpdate(id.Value);

            if (fabricantes == null)
            {
                return NotFound();
            }
            return View(fabricantes);
        }


        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Fabricante fabricante)
        {
            if (id != fabricante.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Fabricante fabricantes = await GatewayServiceProvider.Get<IFabricanteService>().Update(id, fabricante);
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!await Exists(fabricante.ID))
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
            return View(fabricante);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fabricante fabricante = await this.GatewayServiceProvider.Get<IFabricanteService>().Delete(id);
            if (fabricante == null)
            {
                return NotFound();
            }

            return View(fabricante);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Fabricante fabricante = await this.GatewayServiceProvider.Get<IFabricanteService>().DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> Exists(long id)
        {
            bool exists = await this.GatewayServiceProvider.Get<IFabricanteService>().Exists(id);
            return exists;
        }
    }
}
