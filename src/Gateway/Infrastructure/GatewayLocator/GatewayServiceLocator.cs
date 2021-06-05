using Microsoft.Extensions.DependencyInjection;
using SGP.Contract.Service.GatewayContract;
using SGP.Service.GatewayService;

namespace SGP.Infrastructure.GatewayLocator
{
    public static class GatewayServiceLocator
    {
        public static void ConfigureGatewayService(this IServiceCollection services)
        {
            services.AddScoped<IGatewayServiceProvider, GatewayServiceProvider>();
        }
    }
}
