using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class FabricanteService : IFabricanteService
    {
        private readonly SGPContext context;

        public FabricanteService(SGPContext context) => this.context = context;

        public async Task<Fabricante> Create(Fabricante obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<Fabricante> Delete(int? id)
        {
            Fabricante fabricante = new Fabricante();

            return await this.Details(fabricante.Id);
        }

        public async Task<Fabricante> DeleteConfirmed(int id)
        {
            Fabricante fabricante = await context.Fabricante.FindAsync(id);
            context.Fabricante.Remove(fabricante);
            await context.SaveChangesAsync();

            return fabricante;
        }

        public async Task<Fabricante> Details(long? id)
        {
            Fabricante fabricante = await context.Fabricante
               .FirstOrDefaultAsync(m => m.Id == id);

            return fabricante;
        }

        public async Task<bool> Exists(long id)
        {
            return await Task.FromResult(context.Fabricante.Any(e => e.Id == id));
        }

        public async Task<List<Fabricante>> GetAll()
        {
            List<Fabricante> fabricante = await context.Fabricante.ToListAsync();

            return fabricante;
        }

        public async Task<Fabricante> GetUpdate(int id)
        {
            Fabricante fabricante = await context.Fabricante.FindAsync(id);

            return fabricante;
        }

        public async Task<Fabricante> Update(long id, Fabricante obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        }
    }
}
