using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Patrimony.Repository.PatrimonyRepository;
using SGP.Patrimony.Repository.PatrimonyRepository.Service;
using SGP.Patrimony.Service.PatrimonyService;

namespace SGP.Patrimony.Infrastructure.PatrimonyLocator
{
    public static class PatrimonyServicelocator
    {
        public static void ConfigurePatrimonyService(this IServiceCollection services)
        {
            //REPOSITORIES
            services.AddScoped<DbContext, SGPContext>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<ISetorRepository, SetorRepository>();
            services.AddScoped<IClassificacaoDeAtivosRepository, ClassificacaoDeAtivosRepository>();

            //SERVICES
            services.AddScoped<ICategoriaDoItemService, CategoriaDoItemService>();
            services.AddScoped<IClassificacaoDeAtivosService, ClassificacaoDeAtivosService>();
            //services.AddScoped<IModeloDeEquipamentoService, ModeloDeEquipamentoService>();
            services.AddScoped<ISetorService, SetorService>();
            services.AddScoped<IFabricanteService, FabricanteService>();
            services.AddScoped<INotificadorService, NotificadorService>();

            //HTTPCONTEXT
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddScoped<IEquipamentoService, EquipamentoService>();

        }
    }
}
