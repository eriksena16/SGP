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
            List<Manufacturer> manufacturer = await this.GatewayServiceProvider.Get<IManufacturerService>().GetAll();

            return View(manufacturer);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await this.GatewayServiceProvider.Get<IManufacturerService>().Details(id);
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
        public async Task<IActionResult> Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                Manufacturer Manufacturer = await this.GatewayServiceProvider.Get<IManufacturerService>().Create(manufacturer);
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

            Manufacturer manufacturer = await GatewayServiceProvider.Get<IManufacturerService>().GetUpdate(id.Value);

            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }


        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Manufacturer manufacturer)
        {
            if (id != manufacturer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Manufacturer AssetClassification = await GatewayServiceProvider.Get<IManufacturerService>().Update(id, manufacturer);
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

            Manufacturer manufacturer = await this.GatewayServiceProvider.Get<IManufacturerService>().Delete(id);
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
            Manufacturer manufacturer = await this.GatewayServiceProvider.Get<IManufacturerService>().DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> Exists(long id)
        {
            bool exists = await this.GatewayServiceProvider.Get<IManufacturerService>().Exists(id);
            return exists;
        }
    }
}
