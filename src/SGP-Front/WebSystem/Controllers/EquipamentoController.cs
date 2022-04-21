using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGP.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Controllers
{
    public class EquipamentoController : ApplicationController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EquipamentoController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Equipamentos
        public async Task<IActionResult> Index()
        {

            List<EquipamentoViewModel> equipamento = await this.GatewayServiceProvider.Get<IEquipamentoService>().Get();
            return View(equipamento);
        }

        // GET: Equipamentos/Details/5
        public async Task<IActionResult> Details(long id)
        {
          
            Equipamento equipamento = await this.GatewayServiceProvider.Get<IEquipamentoService>().Get(id);

            if (equipamento == null)
            {
                return NotFound();
            }



            return View(equipamento);
        }



        // GET: Equipamentos/Create
        public IActionResult Create()
        {

            DropdownListCategoriaDoItem();
            DropdownListClassificacaoDeAtivos();
            DropdownListModeloDeEquipamento();
            //DropdownListFabricante();
            DropdownListSetor();
            DropdownListResponsavelDoEquipamento();
            return View();
        }

        // POST: Equipamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Equipamento equipamento)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    //if (equipamento.NotaFiscal.Length > 0)
                    //{
                    //    string folder = "uploads/notas/";
                    //    equipamento.NotaFiscalUrl = await Upload(folder, equipamento.NotaFiscal);
                    //}

                    equipamento = await this.GatewayServiceProvider.Get<IEquipamentoService>().Add(equipamento);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }

                          
                return RedirectToAction(nameof(Index));
            }

            DropdownListCategoriaDoItem(equipamento.CategoriaDoItemId);
            DropdownListClassificacaoDeAtivos(equipamento.ClassificacaoDeAtivosId);
            DropdownListModeloDeEquipamento(equipamento.ModeloDeEquipamentoId);
            //DropdownListFabricante(equipamentos.ModeloDeEquipamento.FabricanteId);
            DropdownListSetor(equipamento.SetorId);
            DropdownListResponsavelDoEquipamento(equipamento.ResponsavelDoEquipamentoId);
            return View(equipamento);
        }




        // GET: Equipamentos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return View();
            }

            var equipamentos = await this.GatewayServiceProvider.Get<IEquipamentoService>().Get(id.Value);

            if (equipamentos == null)

            {
                return NotFound();
            }

            //if (equipamentos.NotaFiscal != null)
            //{

            //    equipamentos.NotaFiscalUrl = equipamentos.NotaFiscalUrl;

            //}

            DropdownListCategoriaDoItem(equipamentos.CategoriaDoItemId);
            DropdownListClassificacaoDeAtivos(equipamentos.ClassificacaoDeAtivosId);
            DropdownListModeloDeEquipamento(equipamentos.ModeloDeEquipamentoId);
            //DropdownListFabricante(equipamentos.ModeloDeEquipamento.FabricanteId);
            DropdownListSetor(equipamentos.SetorId);
            DropdownListResponsavelDoEquipamento(equipamentos.ResponsavelDoEquipamentoId);
            return View(equipamentos);
        }


        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Equipamento equipamentos)
        {

            if (id != equipamentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    //if (equipamentos.NotaFiscal.Length > 0)
                    //{
                    //    string folder = "uploads/notas/";
                    //    equipamentos.NotaFiscalUrl = await Upload(folder, equipamentos.NotaFiscal);


                    //}

                    await this.GatewayServiceProvider.Get<IEquipamentoService>().Update(equipamentos);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            DropdownListCategoriaDoItem(equipamentos.CategoriaDoItemId);
            DropdownListClassificacaoDeAtivos(equipamentos.ClassificacaoDeAtivosId);
            DropdownListModeloDeEquipamento(equipamentos.ModeloDeEquipamentoId);
            //DropdownListFabricante(equipamentos.ModeloDeEquipamento.FabricanteId);
            DropdownListSetor(equipamentos.Setor

                );
            DropdownListResponsavelDoEquipamento(equipamentos.ResponsavelDoEquipamentoId);
            return View(equipamentos);
        }

        // GET: Equipamentos/Delete/5
        public async Task<IActionResult> Delete(long id)
        {

            Equipamento equipamento = await this.GatewayServiceProvider.Get<IEquipamentoService>().Get(id);

            if (equipamento == null)
            {
                return NotFound();
            }else
                await this.GatewayServiceProvider.Get<IEquipamentoService>().Delete(equipamento);

            return View(equipamento);
        }

        // POST: Equipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Equipamento equipamentos = await this.GatewayServiceProvider.Get<IEquipamentoService>().Get(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<string> Upload(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return $"/" + folderPath;
        }

        private void DropdownListCategoriaDoItem(object listaCategoria = null)
        {
            var lista = this.GatewayServiceProvider.Get<IEquipamentoService>().DropdownListCategoriaDoItem();
            ViewBag.CategoriaDoItemId = new SelectList(lista, "Id", "Nome", listaCategoria);
        }

        private void DropdownListClassificacaoDeAtivos(object listaClassificacao = null)
        {
            IQueryable<object> lista = this.GatewayServiceProvider.Get<IEquipamentoService>().DropdownListClassificacaoDeAtivos();
            ViewBag.ClassificacaoDeAtivosId = new SelectList(lista, "Id", "Nome", listaClassificacao);
        }

        private void DropdownListModeloDeEquipamento(object listaModelo = null)
        {
            var lista = this.GatewayServiceProvider.Get<IEquipamentoService>().DropdownListModeloDeEquipamento();
            ViewBag.ModeloDeEquipamentoId = new SelectList(lista, "Id", "Nome", listaModelo);
        }
        //private void DropdownListFabricante(object listaFabricante = null)
        //{

        //    IQueryable<object> lista = this.GatewayServiceProvider.Get<IEquipamentoService>().DropdownListFabricante();

        //    ViewBag.FabricanteId = new SelectList(lista, "FabricanteId", "Nome", listaFabricante);
        //}
        private void DropdownListSetor(object listaSetor = null)
        {
            IQueryable<object> lista = this.GatewayServiceProvider.Get<IEquipamentoService>().DropdownListSetor();
            ViewBag.SetorId = new SelectList(lista, "Id", "Nome", listaSetor);
        }
        private void DropdownListResponsavelDoEquipamento(object listaResponsavel = null)
        {
            IQueryable<object> lista = this.GatewayServiceProvider.Get<IEquipamentoService>().DropdownListResponsavelDoEquipamento();
            ViewBag.ResponsavelDoEquipamentoId = new SelectList(lista, "Id", "Nome", listaResponsavel);
        }
    }
}
