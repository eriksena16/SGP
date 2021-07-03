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
            Equipamento exemple = new Equipamento();

            return await this.Details(exemple.EquipamentoID);
        }

        public async Task<Equipamento> DeleteConfirmed(int id)
        {
            Equipamento exemple = await context.Equipamento.FindAsync(id);
            context.Equipamento.Remove(exemple);
            await context.SaveChangesAsync();

            return exemple;
        }

        public async Task<Equipamento> Details(long? id)
        {
            Equipamento exemple = await context.Equipamento
               .FirstOrDefaultAsync(m => m.EquipamentoID == id);

            return exemple;
        }

        public async Task<bool> Exists(long id)
        {
            return await Task.FromResult(context.Equipamento.Any(e => e.EquipamentoID == id));
        }

        public async Task<List<Equipamento>> GetAll()
        {
            List<Equipamento> exemple = await context.Equipamento.ToListAsync();

            return exemple;
        }


        public async Task<Equipamento> GetUpdate(int id)
        {
            Equipamento exemple = await context.Equipamento.FindAsync(id);

            return exemple;
        }

        public async Task<Equipamento> Update(long id, Equipamento obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        }
    }
}
