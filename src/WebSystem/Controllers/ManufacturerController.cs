using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGP.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Controllers
{
    public class ManufacturerController : ApplicationController
    {

        public async Task<IActionResult> Index()
        {
            List<Fabricante> manufacturer = await this.GatewayServiceProvider.Get<IFabricanteService>().GetAll();

            return View(manufacturer);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await this.GatewayServiceProvider.Get<IFabricanteService>().Details(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fabricante manufacturer)
        {
            if (ModelState.IsValid)
            {
                Fabricante Manufacturer = await this.GatewayServiceProvider.Get<IFabricanteService>().Create(manufacturer);
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fabricante manufacturer = await GatewayServiceProvider.Get<IFabricanteService>().GetUpdate(id.Value);

            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }


        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Fabricante manufacturer)
        {
            if (id != manufacturer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Fabricante AssetClassification = await GatewayServiceProvider.Get<IFabricanteService>().Update(id, manufacturer);
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!await Exists(manufacturer.Id))
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
            return View(manufacturer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fabricante manufacturer = await this.GatewayServiceProvider.Get<IFabricanteService>().Delete(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Fabricante manufacturer = await this.GatewayServiceProvider.Get<IFabricanteService>().DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> Exists(long id)
        {
            bool exists = await this.GatewayServiceProvider.Get<IFabricanteService>().Exists(id);
            return exists;
        }
    }
}
