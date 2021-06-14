using Microsoft.Extensions.DependencyInjection;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Patrimony.Service.PatrimonyService;

namespace SGP.Patrimony.Infrastructure.PatrimonyLocator
{
    public static class PatrimonyServicelocator
    {
        public static void ConfigurePatrimonyService( this IServiceCollection services)
        {
            services.AddScoped<IItemCategoryService, ItemCategoryService>();
            services.AddScoped<IAssetClassificationService, AssetClassificationService>();
            services.AddScoped<IEquipmentModelService, EquipmentModelService>();
            services.AddScoped<ISectorService, SectorService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();

        }
    }
}
