using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class SetorService : ISetorService
    {
        private readonly SGPContext context;

        public SetorService(SGPContext context) => this.context = context;

        public async Task<Setor> Create(Setor obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<Setor> Delete(long? id)
        {
            Setor setor = new Setor();

            return await this.Details(setor.ID);
        }

        public async Task<Setor> DeleteConfirmed(long id)
        {
            Setor setor = await context.Setor.FindAsync(id);
            context.Setor.Remove(setor);
            await context.SaveChangesAsync();

            return setor;
        }

        public async Task<Setor> Details(long? id)
        {
            Setor setor = await context.Setor
               .FirstOrDefaultAsync(m => m.ID == id);

            return setor;
        }

        public async Task<bool> Exists(long id)
        {
            return await Task.FromResult(context.Setor.Any(e => e.ID == id));
        }

        public async Task<List<Setor>> GetAll()
        {
            List<Setor> sector = await context.Setor.ToListAsync();

            return sector;
        }


        public async Task<Setor> GetUpdate(long id)
        {
            Setor sector = await context.Setor.FindAsync(id);

            return sector;
        }

        public async Task<Setor> Update(long id, Setor obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        }
    }
}
