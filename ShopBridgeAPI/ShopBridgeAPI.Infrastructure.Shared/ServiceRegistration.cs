using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopBridgeAPI.Application.Interfaces;
using ShopBridgeAPI.Infrastructure.Shared.Services;

namespace ShopBridgeAPI.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
