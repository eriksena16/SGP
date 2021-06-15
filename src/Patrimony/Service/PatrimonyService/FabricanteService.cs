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
            Fabricante manufacturer = new Fabricante();

            return await this.Details(manufacturer.Id);
        }

        public async Task<Fabricante> DeleteConfirmed(int id)
        {
            Fabricante manufacturer = await context.Fabricante.FindAsync(id);
            context.Fabricante.Remove(manufacturer);
            await context.SaveChangesAsync();

            return manufacturer;
        }

        public async Task<Fabricante> Details(long? id)
        {
            Fabricante manufacturer = await context.Fabricante
               .FirstOrDefaultAsync(m => m.Id == id);

            return manufacturer;
        }

        public async Task<bool> Exists(long id)
        {
            return await Task.FromResult(context.Fabricante.Any(e => e.Id == id));
        }

        public async Task<List<Fabricante>> GetAll()
        {
            List<Fabricante> manufacturer = await context.Fabricante.ToListAsync();

            return manufacturer;
        }

        public async Task<Fabricante> GetUpdate(int id)
        {
            Fabricante manufacturer = await context.Fabricante.FindAsync(id);

            return manufacturer;
        }

        public async Task<Fabricante> Update(long id, Fabricante obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        }
    }
}
