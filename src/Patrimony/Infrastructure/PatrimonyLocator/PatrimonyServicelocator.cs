using Microsoft.Extensions.DependencyInjection;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Patrimony.Service.PatrimonyService;

namespace SGP.Patrimony.Infrastructure.PatrimonyLocator
{
    public static class PatrimonyServicelocator
    {
        public static void ConfigurePatrimonyService( this IServiceCollection services)
        {
            services.AddScoped<ICategoriaDoItemService, CategoriaDoItemService>();
            services.AddScoped<IClassificacaoDeAtivosService, ClassificacaoDeAtivosService>();
            services.AddScoped<IModeloDeEquipamentoService, ModeloDeEquipamentoService>();
            services.AddScoped<ISetorService, SetorService>();
            services.AddScoped<IFabricanteService, FabricanteService>();
            services.AddScoped<IEquipamentoService, EquipamentoService>();

        }
    }
}
