using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGP.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGP.Controllers
{
    public class EquipmentModelController : ApplicationController
    {

        public async Task<IActionResult> Index()
        {
            List<ModeloDeEquipamento> equipmentModel = await this.GatewayServiceProvider.Get<IModeloDeEquipamentoService>().GetAll();

            return View(equipmentModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ModeloDeEquipamento equipmentModel = await this.GatewayServiceProvider.Get<IModeloDeEquipamentoService>().Details(id);
            if (equipmentModel == null)
            {
                return NotFound();
            }

            return View(equipmentModel);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModeloDeEquipamento equipmentModel)
        {
            if (ModelState.IsValid)
            {
                ModeloDeEquipamento AssetClassification = await this.GatewayServiceProvider.Get<IModeloDeEquipamentoService>().Create(equipmentModel);
                return RedirectToAction(nameof(Index));
            }
            return View(equipmentModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ModeloDeEquipamento equipmentModel = await GatewayServiceProvider.Get<IModeloDeEquipamentoService>().GetUpdate(id.Value);

            if (equipmentModel == null)
            {
                return NotFound();
            }
            return View(equipmentModel);
        }


        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ModeloDeEquipamento equipmentModel)
        {
            if (id != equipmentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ModeloDeEquipamento EquipmentModel = await GatewayServiceProvider.Get<IModeloDeEquipamentoService>().Update(id, equipmentModel);
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!await Exists(equipmentModel.Id))
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
            return View(equipmentModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ModeloDeEquipamento equipmentModel = await this.GatewayServiceProvider.Get<IModeloDeEquipamentoService>().Delete(id);
            if (equipmentModel == null)
            {
                return NotFound();
            }

            return View(equipmentModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ModeloDeEquipamento equipmentModel = await this.GatewayServiceProvider.Get<IModeloDeEquipamentoService>().DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> Exists(long id)
        {
            var exists = await this.GatewayServiceProvider.Get<IModeloDeEquipamentoService>().Exists(id);
            return exists;
        }
    }
}
