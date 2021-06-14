using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly SGPContext context;

        public ManufacturerService(SGPContext context) => this.context = context;

        public async Task<Manufacturer> Create(Manufacturer obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<Manufacturer> Delete(int? id)
        {
            Manufacturer manufacturer = new Manufacturer();

            return await this.Details(manufacturer.Id);
        }

        public async Task<Manufacturer> DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = await context.Manufacturer.FindAsync(id);
            context.Manufacturer.Remove(manufacturer);
            await context.SaveChangesAsync();

            return manufacturer;
        }

        public async Task<Manufacturer> Details(long? id)
        {
            Manufacturer manufacturer = await context.Manufacturer
               .FirstOrDefaultAsync(m => m.Id == id);

            return manufacturer;
        }

        public async Task<bool> Exists(long id)
        {
            return await Task.FromResult(context.Manufacturer.Any(e => e.Id == id));
        }

        public async Task<List<Manufacturer>> GetAll()
        {
            List<Manufacturer> manufacturer = await context.Manufacturer.ToListAsync();

            return manufacturer;
        }

        public async Task<Manufacturer> GetUpdate(int id)
        {
            Manufacturer manufacturer = await context.Manufacturer.FindAsync(id);

            return manufacturer;
        }

        public async Task<Manufacturer> Update(long id, Manufacturer obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        }
    }
}
