using InsureCompany.ApplicationService.Contracts;
using InsureCompany.ApplicationService.Service;
using Microsoft.Extensions.DependencyInjection;
using InsureCompany.Infrastructure;
using InsureCompany.ApplicationService.ApiData;

namespace InsureCompany.ApplicationService.Extension
{
    public static class ApplicationDI
    {
        public static void AddApplicationDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddInfrastructureServices(connectionString);
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IPolicyService, PolicyService>();
            services.AddScoped<IDataFetchService, DataFetchService>();


            services.AddHostedService<DataSeederHostedService>();
        }

        public static void CreateDBApplication(this IServiceProvider services)
        {
            services.CreateDB();
        }
    }
}
