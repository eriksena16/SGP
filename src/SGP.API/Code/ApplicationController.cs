using Microsoft.AspNetCore.Mvc;
using SGP.Contract.Service.GatewayContract;


namespace SGP.API.Code
{
    public class ApplicationController : Controller
    {
        private IGatewayServiceProvider _gatewayServiceProvider;

        private IGatewayServiceProvider Create()
        {
            IGatewayServiceProvider gatewayServiceProvider = (IGatewayServiceProvider)this.HttpContext?.RequestServices?.GetService(typeof(IGatewayServiceProvider));

            return gatewayServiceProvider;
        }

        public IGatewayServiceProvider GatewayServiceProvider
        {
            get
            {
                if (_gatewayServiceProvider == null)
                    _gatewayServiceProvider = this.Create();
                return (_gatewayServiceProvider);
            }
        }
    }
}
