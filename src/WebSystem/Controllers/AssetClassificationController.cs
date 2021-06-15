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
            List<ClassificacaoDeAtivos> assetClassification = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().GetAll();

            return View(assetClassification);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetClassification = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Details(id);
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
        public async Task<IActionResult> Create(ClassificacaoDeAtivos assetClassification)
        {
            if (ModelState.IsValid)
            {
                ClassificacaoDeAtivos AssetClassification = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Create(assetClassification);
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

            ClassificacaoDeAtivos assetClassification = await GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().GetUpdate(id.Value);

            if (assetClassification == null)
            {
                return NotFound();
            }
            return View(assetClassification);
        }


        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClassificacaoDeAtivos assetClassification)
        {
            if (id != assetClassification.AssetClassificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ClassificacaoDeAtivos AssetClassification = await GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Update(id, assetClassification);
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

            var assetClassification = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Delete(id);
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
            var assetClassification = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> Exists(int id)
        {
            var exists = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Exists(id);
            return exists;
        }
    }
}
