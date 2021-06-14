using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class AssetClassificationService : IAssetClassificationService
    {
        private readonly SGPContext context;
        public AssetClassificationService(SGPContext context) => this.context = context;

        public async Task<AssetClassification> Create(AssetClassification obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<AssetClassification> Delete(int? id)
        {
            AssetClassification assetClassification = new AssetClassification();
            return await this.Details(assetClassification.Id);
        }

        public async Task<AssetClassification> DeleteConfirmed(int id)
        {
            AssetClassification assetClassification = await context.AssetClassification.FindAsync(id);

            context.AssetClassification.Remove(assetClassification);
            await context.SaveChangesAsync();

            return assetClassification;
        }

        public async Task<AssetClassification> Details(long? id)
        {
            AssetClassification assetClassification = await context.AssetClassification
               .FirstOrDefaultAsync(m => m.Id == id);

            return assetClassification;
        }

        public async Task<bool> Exists(long id)
        {
            return await Task.FromResult(context.AssetClassification.Any(e => e.Id == id));
        }

        public async Task<List<AssetClassification>> GetAll()
        {
            List<AssetClassification> assetClassification = await context.AssetClassification.ToListAsync();

            return assetClassification;
        }

        public async Task<AssetClassification> GetUpdate(int id)
        {
            AssetClassification assetClassification = await context.AssetClassification.FindAsync(id);

            return assetClassification;
        }

        public async Task<AssetClassification> Update(long id, AssetClassification obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        }
    }
}
