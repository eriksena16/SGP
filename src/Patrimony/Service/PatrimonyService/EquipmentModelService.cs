using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class EquipmentModelService : IEquipmentModelService
    {
        private readonly SGPContext context;
       
        public EquipmentModelService(SGPContext context) => this.context = context;

        public async Task<EquipmentModel> Create(EquipmentModel obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<EquipmentModel> Delete(int? id)
        {
            EquipmentModel equipmentModel = new EquipmentModel();

            return await this.Details(equipmentModel.EquipmentModelId);
        }

        public async Task<EquipmentModel> DeleteConfirmed(int id)
        {
            EquipmentModel equipmentModel = await context.EquipmentModel.FindAsync(id);

            context.EquipmentModel.Remove(equipmentModel);
            await context.SaveChangesAsync();

            return equipmentModel;
        }

        public async Task<EquipmentModel> Details(int? id)
        {
            EquipmentModel equipmentModel = await context.EquipmentModel
               .FirstOrDefaultAsync(m => m.EquipmentModelId == id);

            return equipmentModel;
        }

        public async Task<bool> Exists(int id)
        {
            return await Task.FromResult(context.EquipmentModel.Any(e => e.EquipmentModelId == id));
        }

        public async Task<List<EquipmentModel>> GetAll()
        {
            List<EquipmentModel> equipmentModel = await context.EquipmentModel.ToListAsync();

            return equipmentModel;
        }

        public async Task<EquipmentModel> GetUpdate(int id)
        {
            EquipmentModel equipmentModel = await context.EquipmentModel.FindAsync(id);

            return equipmentModel;
        }

        public async Task<EquipmentModel> Update(int id, EquipmentModel obj)
        {
            context.Update(obj);
            await context.SaveChangesAsync();

            return obj;
        }
    }
}
