using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGP.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Controllers
{
    public class AssetClassificationController : ApplicationController
    {

        public async Task<IActionResult> Index()
        {
            List<AssetClassification> assetClassification = await this.GatewayServiceProvider.Get<IAssetClassificationService>().GetAll();

            return View(assetClassification);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetClassification = await this.GatewayServiceProvider.Get<IAssetClassificationService>().Details(id);
            if (assetClassification == null)
            {
                return NotFound();
            }

            return View(assetClassification);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssetClassification assetClassification)
        {
            if (ModelState.IsValid)
            {
                AssetClassification AssetClassification = await this.GatewayServiceProvider.Get<IAssetClassificationService>().Create(assetClassification);
                return RedirectToAction(nameof(Index));
            }
            return View(assetClassification);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AssetClassification assetClassification = await GatewayServiceProvider.Get<IAssetClassificationService>().GetUpdate(id.Value);

            if (assetClassification == null)
            {
                return NotFound();
            }
            return View(assetClassification);
        }


        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AssetClassification assetClassification)
        {
            if (id != assetClassification.AssetClassificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AssetClassification AssetClassification = await GatewayServiceProvider.Get<IAssetClassificationService>().Update(id, assetClassification);
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!await Exists(assetClassification.AssetClassificationId))
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
            return View(assetClassification);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetClassification = await this.GatewayServiceProvider.Get<IAssetClassificationService>().Delete(id);
            if (assetClassification == null)
            {
                return NotFound();
            }

            return View(assetClassification);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetClassification = await this.GatewayServiceProvider.Get<IAssetClassificationService>().DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> Exists(int id)
        {
            var exists = await this.GatewayServiceProvider.Get<IAssetClassificationService>().Exists(id);
            return exists;
        }
    }
}
