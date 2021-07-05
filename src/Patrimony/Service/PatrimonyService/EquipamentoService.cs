using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyRepository;
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

        public async Task<Equipamento> Delete(int? id)
        {
            Equipamento equipamento = new Equipamento();

            return await this.Details(equipamento.EquipamentoID);
        }

        public async Task<Equipamento> DeleteConfirmed(int id)
        {
            Equipamento equipamento = await context.Equipamento.FindAsync(id);
            context.Equipamento.Remove(equipamento);
            await context.SaveChangesAsync();

            return equipamento;
        }

        public async Task<Equipamento> Details(long? id)
        {
            
            Equipamento equipamento = await context.Equipamento
                 .Include(e => e.CategoriaDoItem)
                 .Include(e => e.CategoriaDoItem)
                 .Include(e => e.ModeloDeEquipamento)
                 .Include(e => e.Fabricante)
                 .Include(e => e.ResponsavelDoEquipamento)
                 .Include(e => e.Setor)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.EquipamentoID == id);

            equipamento.Idade = CalcularTempoDeUso.CalcularTempoDeUsoDoEquipamento(equipamento.Idade.Value);
            equipamento.ValorAtual = CalcularDepreciacao.CalcularValorAtualDoEquipamento(equipamento.Idade.Value);

            return equipamento;
        }

        public async Task<bool> Exists(long id)
        {
            return await Task.FromResult(context.Equipamento.Any(e => e.EquipamentoID == id));
        }

        public async Task<List<Equipamento>> GetAll()
        {
            
            List<Equipamento> equipamento = await context.Equipamento
                 .Include(e => e.CategoriaDoItem)
                 .Include(e => e.CategoriaDoItem)
                 .Include(e => e.ModeloDeEquipamento)
                 .Include(e => e.Fabricante)
                 .Include(e => e.ResponsavelDoEquipamento)
                 .Include(e => e.Setor)
                 .AsNoTracking()
                 .ToListAsync();
           
          
                return equipamento;
        }


        public async Task<Equipamento> GetUpdate(int id)
        {
            Equipamento equipamento = await context.Equipamento.FindAsync(id);

            return equipamento;
        }

        public async Task<Equipamento> Update(long id, Equipamento obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        }


        public IEnumerable<object> DropdownListCategoriaDoItem()
        {
            IQueryable<object> categoriasQuery = from _ in context.Categoria
                                                 orderby _.Nome
                                                 select _;
            return categoriasQuery;
        }

        public IEnumerable<object> DropdownListClassificacaoDeAtivos()
        {
            var classificacaoQuery = from _ in context.Classificacao
                                     orderby _.Nome
                                     select _;

            return classificacaoQuery;
        }

        public IEnumerable<object> DropdownListModeloDeEquipamento()
        {
            IQueryable<object> modeloDeEquipamentoQuery = from _ in context.ModeloDeEquipamento
                                                 orderby _.Nome
                                                 select _;
            return modeloDeEquipamentoQuery;
        }

        public IEnumerable<object> DropdownListFabricante()
        {
            IQueryable<object> fabricanteQuery = from _ in context.Fabricante
                                                 orderby _.Nome
                                                 select _;
            return fabricanteQuery;
        }

        public IEnumerable<object> DropdownListSetor()
        {
            IQueryable<object> setorQuery = from _ in context.Setor
                                            orderby _.Nome
                                            select _;
            return setorQuery;
        }

        public IEnumerable<object> DropdownListResponsavelDoEquipamento()
        {
            IQueryable<object> responsavelQuery = from _ in context.ResponsavelDoEquipamento
                                                  orderby _.Nome
                                                  select _;
            return responsavelQuery;
        }

    }
}
