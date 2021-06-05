namespace SGP.Contract.Service.GatewayContract
{
    public interface IGatewayServiceProvider
    {
        T Get<T>();
    }
}
