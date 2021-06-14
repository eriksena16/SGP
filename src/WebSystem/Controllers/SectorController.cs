using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGP.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Controllers
{
    public class SectorController : ApplicationController
    {
        public async Task<IActionResult> Index()
        {
            List<Sector> sector = await this.GatewayServiceProvider.Get<ISectorService>().GetAll();

            return View(sector);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await this.GatewayServiceProvider.Get<ISectorService>().Details(id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sector sector)
        {
            if (ModelState.IsValid)
            {
                Sector Sector = await this.GatewayServiceProvider.Get<ISectorService>().Create(sector);
                return RedirectToAction(nameof(Index));
            }
            return View(sector);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sector sector = await GatewayServiceProvider.Get<ISectorService>().GetUpdate(id.Value);

            if (sector == null)
            {
                return NotFound();
            }
            return View(sector);
        }


        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sector sector)
        {
            if (id != sector.SectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Sector Sector = await GatewayServiceProvider.Get<ISectorService>().Update(id, sector);
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!await Exists(sector.SectorId))
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
            return View(sector);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await this.GatewayServiceProvider.Get<ISectorService>().Delete(id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sector = await this.GatewayServiceProvider.Get<ISectorService>().DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> Exists(int id)
        {
            var exists = await this.GatewayServiceProvider.Get<ISectorService>().Exists(id);
            return exists;
        }
    }
}
