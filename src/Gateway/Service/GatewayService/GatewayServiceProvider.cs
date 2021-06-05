using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SGP.Contract.Service.GatewayContract;

namespace SGP.Service.GatewayService
{
    public class GatewayServiceProvider : IGatewayServiceProvider
    {
        private readonly IHttpContextAccessor _httpContext;
        public GatewayServiceProvider(IHttpContextAccessor httpContext)
        {
            this._httpContext = httpContext;
        }
        public T Get<T>()
        {
            return (this._httpContext.HttpContext.RequestServices.GetService<T>());
        }
    }
}
