//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using SGP.Code;
//using SGP.Contract.Service.PatrimonyContract;
//using SGP.Model.Entity;
//using System.Collections.Generic;
//using System.Threading.Tasks;


//namespace SGP.Controllers
//{
//    public class ModeloDoEquipamentoController : ApplicationController
//    {

//        public async Task<IActionResult> Index()
//        {
//            List<ModeloDeEquipamento> modeloDeEquipamento = await this.GatewayServiceProvider.Get<IModeloDeEquipamentoService>().GetAll();

//            return View(modeloDeEquipamento);
//        }

//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            ModeloDeEquipamento modeloDeEquipamento = await this.GatewayServiceProvider.Get<IModeloDeEquipamentoService>().Get(id);
//            if (modeloDeEquipamento == null)
//            {
//                return NotFound();
//            }

//            return View(modeloDeEquipamento);
//        }


//        public IActionResult Create()
//        {
//            return View();
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(ModeloDeEquipamento modeloDeEquipamento)
//        {
//            if (ModelState.IsValid)
//            {
//                ModeloDeEquipamento modeloDeEquipamento1 = await this.GatewayServiceProvider.Get<IModeloDeEquipamentoService>().Create(modeloDeEquipamento);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(modeloDeEquipamento);
//        }

//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            ModeloDeEquipamento modeloDeEquipamento = await GatewayServiceProvider.Get<IModeloDeEquipamentoService>().GetUpdate(id.Value);

//            if (modeloDeEquipamento == null)
//            {
//                return NotFound();
//            }
//            return View(modeloDeEquipamento);
//        }


//        [HttpPatch]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(long id, ModeloDeEquipamento modeloDeEquipamento)
//        {
//            if (id != modeloDeEquipamento.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    ModeloDeEquipamento ModeloDeEquipamento = await GatewayServiceProvider.Get<IModeloDeEquipamentoService>().Update(id, modeloDeEquipamento);
//                }
//                catch (DbUpdateConcurrencyException)
//                {

//                    if (!await Exists(modeloDeEquipamento.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(modeloDeEquipamento);
//        }

//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            ModeloDeEquipamento modeloDeEquipamento = await this.GatewayServiceProvider.Get<IModeloDeEquipamentoService>().Delete(id);
//            if (modeloDeEquipamento == null)
//            {
//                return NotFound();
//            }

//            return View(modeloDeEquipamento);
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            ModeloDeEquipamento modeloDeEquipamento = await this.GatewayServiceProvider.Get<IModeloDeEquipamentoService>().DeleteConfirmed(id);

//            return RedirectToAction(nameof(Index));
//        }

//        private async Task<bool> Exists(long id)
//        {
//            var exists = await this.GatewayServiceProvider.Get<IModeloDeEquipamentoService>().Exists(id);
//            return exists;
//        }
//    }
//}
