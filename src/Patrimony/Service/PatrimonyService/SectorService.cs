using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    class SectorService : ISectorService
    {
        private readonly SGPContext context;

        public SectorService(SGPContext context) => this.context = context;

        public async Task<Sector> Create(Sector obj)
        {
            Sector sector = new Sector();
            context.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<Sector> Delete(int? id)
        {
            Sector sector = new Sector();

            return await this.Details(sector.SectorId);
        }

        public async Task<Sector> DeleteConfirmed(int id)
        {
            Sector sector = await context.Sector.FindAsync(id);
            context.Sector.Remove(sector);
            await context.SaveChangesAsync();

            return sector;
        }

        public async Task<Sector> Details(int? id)
        {
            Sector sector = await context.Sector
               .FirstOrDefaultAsync(m => m.SectorId == id);

            return sector;
        }

        public async Task<bool> Exists(int id)
        {
            return await Task.FromResult(context.Sector.Any(e => e.SectorId == id));
        }

        public async Task<List<Sector>> GetAll()
        {
            List<Sector> sector = await context.Sector.ToListAsync();

            return sector;
        }


        public async Task<Sector> GetUpdate(int id)
        {
            Sector sector = await context.Sector.FindAsync(id);

            return sector;
        }

        public async Task<Sector> Update(int id, Sector obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        }
    }
}
