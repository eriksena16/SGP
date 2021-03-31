using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGP.Data;
using SGP.Models.Categorias;
using System.Linq;

namespace SGP.Controllers.Equipamento
{
    public class EquipamentosController : Controller
    {
        private readonly SGPContext _context;

        public EquipamentosController(SGPContext context)
        {
            _context = context;
        }

        // GET: Equipamentos
        public async Task<IActionResult> Index()
        {
            
            var equipamentos = await _context.Equipamentos
                 .Include(c => c.Categoria)
                 .Include(cl => cl.Classificacao)
                 .Include(f => f.Fornecedor)
                 .Include(r => r.Responsavel)
                 .Include(s => s.Setor)
                 .AsNoTracking()
                 .ToListAsync();
            return View(equipamentos);
        }

        // GET: Equipamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamentos = await _context.Equipamentos
                .Include(c => c.Categoria)
                .Include(cl => cl.Classificacao)
                .Include(f => f.Fornecedor)
                .Include(r => r.Responsavel)
                .Include(s => s.Setor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EquipamentoID == id);
          
            equipamentos.Idade = DateTime.Now.Year - equipamentos.DataDeCompra.Year;

            if (DateTime.Now.Month >= equipamentos.DataDeCompra.Month && DateTime.Now.Day >= equipamentos.DataDeCompra.Day)
            {
                
                equipamentos.ValorAtual = equipamentos.CalcularValorAtual(equipamentos.Idade);
            }
            else
            {
                equipamentos.Idade -= 1;
                equipamentos.ValorAtual = equipamentos.CalcularValorAtual(equipamentos.Idade);
            }
            



            if (equipamentos == null)
            {
                return NotFound();
            }

            return View(equipamentos);
        }

       

        // GET: Equipamentos/Create
        public IActionResult Create()
        {
            
            ViewBag.ClassificacaoID = new SelectList(_context.Classificacao, "ClassificacaoID", "Nome");
            ViewBag.FornecedorID = new SelectList(_context.Fornecedores, "FornecedorID", "Nome");
            ViewBag.SetorID = new SelectList(_context.Setor, "SetorID", "Nome");
            ViewBag.ResponsavelID = new SelectList(_context.Responsavel, "ResponsavelID", "Nome");
            
            DropdownListCategoria();
            DropdownListClassificacao();
            DropdownListFornecedor();
            DropdownListSetor();
            DropdownListResponsavel();
            return View();
        }

        // POST: Equipamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipamentoID,CategoriaID,ClassificacaoID,Nota,ValorDeCompra,DataDeCompra,Modelo,FornecedorID,Serie,Status,ResponsavelID,SetorID,EstadoDeConservacao,Observacao")] Models.Equipamentos.Equipamento equipamentos)
        {
         
           
                if (ModelState.IsValid)
                {
                    _context.Add(equipamentos);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            
      
            DropdownListCategoria(equipamentos.ClassificacaoID);
            DropdownListClassificacao(equipamentos.ClassificacaoID);
            DropdownListFornecedor(equipamentos.ClassificacaoID);
            DropdownListSetor(equipamentos.ClassificacaoID);
            DropdownListResponsavel(equipamentos.ClassificacaoID);
            return View(equipamentos);
        }

        // GET: Equipamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamentos = await _context.Equipamentos
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EquipamentoID == id);
            if (equipamentos == null)

            {
                return NotFound();
            }
            DropdownListCategoria(equipamentos.CategoriaID);
            DropdownListCategoria(equipamentos.ClassificacaoID);
            DropdownListClassificacao(equipamentos.ClassificacaoID);
            DropdownListFornecedor(equipamentos.ClassificacaoID);
            DropdownListSetor(equipamentos.ClassificacaoID);
            DropdownListResponsavel(equipamentos.ClassificacaoID);
            return View(equipamentos);
        }

        // POST: Equipamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipamentoID,CategoriaID,ClassificacaoID,Nota,ValorDeCompra,DataDeCompra,Modelo,FornecedorID,Serie,Status,ResponsavelID,SetorID,EstadoDeConservacao,Observacao")] Models.Equipamentos.Equipamento equipamentos)
        {

            if (id != equipamentos.EquipamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipamentosExists(equipamentos.EquipamentoID))
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
            DropdownListCategoria(equipamentos.CategoriaID);
            DropdownListClassificacao(equipamentos.ClassificacaoID);
            DropdownListFornecedor(equipamentos.ClassificacaoID);
            DropdownListSetor(equipamentos.ClassificacaoID);
            DropdownListResponsavel(equipamentos.ClassificacaoID);
            return View(equipamentos);
        }

        private void DropdownListCategoria(object listaCategoria = null)
        {
           
            IQueryable<object> categoriasQuery = from c in _context.Categoria
                                                 orderby c.Nome
                                                 select c;
            ViewBag.CategoriaID = new SelectList(categoriasQuery, "CategoriaID", "Nome", listaCategoria);
        }

        private void DropdownListClassificacao( object listaClassificacao = null)
        {
            IQueryable<object> classificacaoQuery = from cl in _context.Classificacao
                                                    orderby cl.Nome
                                                    select cl;
            ViewBag.ClassificacaoID = new SelectList(classificacaoQuery, "ClassificacaoID", "Nome", listaClassificacao);
        }

        private void DropdownListFornecedor(object listaFornecedor = null)
        {
            IQueryable<object> fornecedorQuery = from f in _context.Fornecedores
                                                    orderby f.Nome
                                                    select f;
            ViewBag.FornecedorID = new SelectList(fornecedorQuery, "FornecedorID", "Nome", listaFornecedor);
        }

        private void DropdownListSetor(object listaSetor = null)
        {
            IQueryable<object> setorQuery = from s in _context.Setor
                                                 orderby s.Nome
                                                 select s;
            ViewBag.SetorID = new SelectList(setorQuery, "SetorID", "Nome", listaSetor);
        }

        private void DropdownListResponsavel(object listaResponsavel = null)
        {
            IQueryable<object> responsavelQuery = from r in _context.Responsavel
                                            orderby r.Nome
                                            select r;
            ViewBag.ResponsavelID = new SelectList(responsavelQuery, "ResponsavelID", "Nome", listaResponsavel);
        }

        // GET: Equipamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id == null)
            {
                return NotFound();
            }

            var equipamentos = await _context.Equipamentos
                .Include(c => c.Categoria)
                .Include(cl => cl.Classificacao)
                .Include(f => f.Fornecedor)
                .Include(r => r.Responsavel)
                .Include(s => s.Setor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EquipamentoID == id);
            if (equipamentos == null)
            {
                return NotFound();
            }

            return View(equipamentos);
        }

        // POST: Equipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipamentos = await _context.Equipamentos.FindAsync(id);
            _context.Equipamentos.Remove(equipamentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipamentosExists(int id)
        {
            return _context.Equipamentos.Any(e => e.EquipamentoID == id);
        }
    }
}
