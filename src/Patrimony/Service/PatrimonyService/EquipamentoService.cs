using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class EquipamentoService : IEquipamentoService
    {
        private readonly SGPContext context;

        public EquipamentoService(SGPContext context) => this.context = context;

        public async Task<Equipamento> Create(Equipamento obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<Equipamento> Delete(long? id)
        {
            return await Get(id);
        }

        public async Task<Equipamento> DeleteConfirmed(long id)
        {
            Equipamento equipamento = await context.Equipamento.FindAsync(id);
            context.Equipamento.Remove(equipamento);
            await context.SaveChangesAsync();

            return equipamento;
        }

        public async Task<Equipamento> Get(long? id)
        {
            
            Equipamento equipamento = await context.Equipamento
                 .Include(e => e.CategoriaDoItem)
                 .Include(e => e.ClassificacaoDeAtivos)
                 .Include(e => e.ModeloDeEquipamento)
                 .ThenInclude(e => e.Fabricante)
                 .Include(e => e.ResponsavelDoEquipamento)
                 .Include(e => e.Setor)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.Id == id);

            equipamento.Idade = CalcularTempoDeUsoDoEquipamento(equipamento.Id, equipamento.Idade);
            equipamento.ValorAtual = CalcularValorAtualDoEquipamento(equipamento.Id, equipamento.Idade);

            return equipamento;
        }

        public async Task<bool> Exists(long id)
        {
            return await Task.FromResult(context.Equipamento.Any(e => e.Id == id));
        }

        public async Task<List<Equipamento>> GetAll()
        {
            
            List<Equipamento> equipamento = await context.Equipamento
                 .Include(e => e.CategoriaDoItem)
                 .Include(e => e.ClassificacaoDeAtivos)
                 .Include(e => e.ModeloDeEquipamento)
                 .ThenInclude(e => e.Fabricante)
                 .Include(e => e.ResponsavelDoEquipamento)
                 .Include(e => e.Setor)
                 .AsNoTracking()
                 .ToListAsync();
           
          
                return equipamento;
        }


        public async Task<Equipamento> GetUpdate(long id)
        {
            Equipamento equipamento = await context.Equipamento.FindAsync(id);
            DropdownListCategoriaDoItem();
            DropdownListClassificacaoDeAtivos();
            DropdownListFabricante();
            DropdownListModeloDeEquipamento();
            DropdownListResponsavelDoEquipamento();
            DropdownListSetor();

            return equipamento;
        }

        public async Task<Equipamento> Update(long id, Equipamento obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        }


        public IQueryable<object> DropdownListCategoriaDoItem()
        {
            var categoriasQuery = from _ in context.Categoria
                                                 orderby _.Nome
                                                 select _;
            return categoriasQuery;
        }

        public IQueryable<object> DropdownListClassificacaoDeAtivos()
        {
            IQueryable<object> classificacaoQuery = from _ in context.Classificacao
                                     orderby _.Nome
                                     select _;
            return classificacaoQuery;
           
        }

        public IQueryable<object> DropdownListModeloDeEquipamento()
        {
            IQueryable<object> modeloDeEquipamentoQuery = from _ in context.ModeloDeEquipamento
                                                          orderby _.Nome
                                                 select _;
            //modeloDeEquipamentoQuery = modeloDeEquipamentoQuery.OrderBy<List<ModeloDeEquipamento>>(_ => _);
            return  modeloDeEquipamentoQuery;
        }
        
        public IQueryable<object> DropdownListFabricante()
        {
            IQueryable<object> fabricanteQuery = from _ in context.Fabricante
                                                 orderby _.Nome
                                                 select _;
            return fabricanteQuery;
        }

        public IQueryable<object> DropdownListSetor()
        {
            IQueryable<object> setorQuery = from _ in context.Setor
                                            orderby _.Nome
                                            select _;
            return setorQuery;
        }

        public IQueryable<object> DropdownListResponsavelDoEquipamento()
        {
            IQueryable<object> responsavelQuery = from _ in context.ResponsavelDoEquipamento
                                                  orderby _.Nome
                                                  select _;
            return responsavelQuery;
        }

        public int CalcularTempoDeUsoDoEquipamento(long id, int idade)
        {
            var equipamento = context.Equipamento.FirstOrDefault(c=> c.Id == id);

           
            idade = DateTime.Now.Year - equipamento.DataDeCompra.Year;
            if (DateTime.Now.Month >= equipamento.DataDeCompra.Month && DateTime.Now.Day >= equipamento.DataDeCompra.Day)
            {

                equipamento.ValorAtual = CalcularValorAtualDoEquipamento(equipamento.Id, idade);
            }
            else
            {
                equipamento.Idade -= 1;
                equipamento.ValorAtual = CalcularValorAtualDoEquipamento(equipamento.Id, idade);
            }
            return idade;
        }

        public decimal CalcularValorAtualDoEquipamento(long id, int idade)
        {
            var equipamento = context.Equipamento.Include(c => c.ClassificacaoDeAtivos).FirstOrDefault(c => c.Id == id);
           
            var percentual = Convert.ToDecimal(equipamento.ClassificacaoDeAtivos.TaxaDeDepreciacao) / 100; // 0,2
            decimal vt = equipamento.ValorDeCompra * percentual; // 3200 * 0,2 = 640

            return equipamento.ValorAtual = equipamento.ValorDeCompra - (vt * idade);// 3200 - (640*3) = 1920
        }

    }
}
