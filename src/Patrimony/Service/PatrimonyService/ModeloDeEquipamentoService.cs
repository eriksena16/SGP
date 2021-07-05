using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class ModeloDeEquipamentoService : IModeloDeEquipamentoService
    {
        private readonly SGPContext context;
       
        public ModeloDeEquipamentoService(SGPContext context) => this.context = context;

        public async Task<ModeloDeEquipamento> Create(ModeloDeEquipamento obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<ModeloDeEquipamento> Delete(int? id)
        {
            ModeloDeEquipamento modeloDeEquipamento = new ModeloDeEquipamento();

            return await this.Details(modeloDeEquipamento.Id);
        }

        public async Task<ModeloDeEquipamento> DeleteConfirmed(int id)
        {
            ModeloDeEquipamento modeloDeEquipamento = await context.ModeloDeEquipamento.FindAsync(id);

            context.ModeloDeEquipamento.Remove(modeloDeEquipamento);
            await context.SaveChangesAsync();

            return modeloDeEquipamento;
        }

        public async Task<ModeloDeEquipamento> Details(long? id)
        {
            ModeloDeEquipamento modeloDeEquipamento = await context.ModeloDeEquipamento
               .FirstOrDefaultAsync(m => m.Id == id);

            return modeloDeEquipamento;
        }

        public async Task<bool> Exists(long id)
        {
            return await Task.FromResult(context.ModeloDeEquipamento.Any(e => e.Id == id));
        }

        public async Task<List<ModeloDeEquipamento>> GetAll()
        {
            List<ModeloDeEquipamento> modeloDeEquipamento = await context.ModeloDeEquipamento.ToListAsync();

            return modeloDeEquipamento;
        }

        public async Task<ModeloDeEquipamento> GetUpdate(int id)
        {
            ModeloDeEquipamento modeloDeEquipamento = await context.ModeloDeEquipamento.FindAsync(id);

            return modeloDeEquipamento;
        }

        public async Task<ModeloDeEquipamento> Update(long id, ModeloDeEquipamento obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        }
    }
}
