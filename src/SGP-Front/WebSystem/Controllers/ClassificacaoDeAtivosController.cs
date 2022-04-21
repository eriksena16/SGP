//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using SGP.Code;
//using SGP.Contract.Service.PatrimonyContract;
//using SGP.Model.Entity;
//using System.Collections.Generic;
//using System.Threading.Tasks;


//namespace SGP.Controllers
//{
//    public class ClassificacaoDeAtivosController : ApplicationController
//    {

//        public async Task<IActionResult> Index()
//        {
//            List<ClassificacaoDeAtivos> assetClassification = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Get();

//            return View(assetClassification);
//        }

//        public async Task<IActionResult> Details(long? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var assetClassification = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Get(id);
//            if (assetClassification == null)
//            {
//                return NotFound();
//            }

//            return View(assetClassification);
//        }


//        public IActionResult Create()
//        {
//            return View();
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(ClassificacaoDeAtivos classificacaoDeAtivos)
//        {
//            if (ModelState.IsValid)
//            {
//                ClassificacaoDeAtivos ClassificacaoDeAtivo = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Create(classificacaoDeAtivos);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(classificacaoDeAtivos);
//        }

//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            ClassificacaoDeAtivos assetClassification = await GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().GetUpdate(id.Value);

//            if (assetClassification == null)
//            {
//                return NotFound();
//            }
//            return View(assetClassification);
//        }


//        [HttpPatch]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(long id, ClassificacaoDeAtivos classificacaoDeAtivos)
//        {
//            if (id != classificacaoDeAtivos.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    ClassificacaoDeAtivos ClassificacaoDeAtivo = await GatewayServiceProvider.Get<IClassificacaoDeAtivosService>()
//                        .Update(id, classificacaoDeAtivos);
//                }
//                catch (DbUpdateConcurrencyException)
//                {

//                    if (!await Exists(classificacaoDeAtivos.Id))
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
//            return View(classificacaoDeAtivos);
//        }

//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var classificacaoDeAtivos = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Delete(id);
//            if (classificacaoDeAtivos == null)
//            {
//                return NotFound();
//            }

//            return View(classificacaoDeAtivos);
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var classificacaoDeAtivos = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().DeleteConfirmed(id);

//            return RedirectToAction(nameof(Index));
//        }

//        private async Task<bool> Exists(long id)
//        {
//            var exists = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Exists(id);
//            return exists;
//        }
//    }
//}
