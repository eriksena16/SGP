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
            List<EquipmentModel> equipmentModel = await this.GatewayServiceProvider.Get<IEquipmentModelService>().GetAll();

            return View(equipmentModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EquipmentModel equipmentModel = await this.GatewayServiceProvider.Get<IEquipmentModelService>().Details(id);
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
        public async Task<IActionResult> Create(EquipmentModel equipmentModel)
        {
            if (ModelState.IsValid)
            {
                EquipmentModel AssetClassification = await this.GatewayServiceProvider.Get<IEquipmentModelService>().Create(equipmentModel);
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

            EquipmentModel equipmentModel = await GatewayServiceProvider.Get<IEquipmentModelService>().GetUpdate(id.Value);

            if (equipmentModel == null)
            {
                return NotFound();
            }
            return View(equipmentModel);
        }


        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EquipmentModel equipmentModel)
        {
            if (id != equipmentModel.EquipmentModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    EquipmentModel EquipmentModel = await GatewayServiceProvider.Get<IEquipmentModelService>().Update(id, equipmentModel);
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!await Exists(equipmentModel.EquipmentModelId))
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

            EquipmentModel equipmentModel = await this.GatewayServiceProvider.Get<IEquipmentModelService>().Delete(id);
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
            EquipmentModel equipmentModel = await this.GatewayServiceProvider.Get<IEquipmentModelService>().DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> Exists(int id)
        {
            var exists = await this.GatewayServiceProvider.Get<IEquipmentModelService>().Exists(id);
            return exists;
        }
    }
}
