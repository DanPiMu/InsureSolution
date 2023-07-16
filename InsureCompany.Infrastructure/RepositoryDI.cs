using InsureCompany.DomainModel.RepositoryContracts;
using InsureCompany.Infrastructure.Persistence;
using InsureCompany.Infrastructure.RespositoryImplementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureCompany.Infrastructure
{
    public static class RepositoryDI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IPolicyRepository, PolicyRepository>();
            return services;
        }

        public static void CreateDB(this IServiceProvider services)
        {
            var db = services.GetRequiredService<AppDbContext>();
            // db.Database.EnsureDeleted(); //revision
            db.Database.EnsureCreated();
        }
    }
}
