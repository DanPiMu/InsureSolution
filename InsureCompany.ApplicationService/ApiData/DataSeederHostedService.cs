using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InsureCompany.DomainModel.RepositoryContracts;
using InsureCompany.ApplicationService.Service;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InsureCompany.ApplicationService.ApiData
{
    public class DataSeederHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DataSeederHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dataFetchService = scope.ServiceProvider.GetRequiredService<IDataFetchService>();
                var clientRepository = scope.ServiceProvider.GetRequiredService<IClientRepository>();
                var policyRepository = scope.ServiceProvider.GetRequiredService<IPolicyRepository>();

                var clients = await dataFetchService.FetchClientsFromApiAsync();
                var policies = await dataFetchService.FetchPoliciesFromApiAsync();

                var existingClients = await clientRepository.GetAllAsync();
                var existingPolicies = await policyRepository.GetAllAsync();

                var newClients = clients.Where(c => !existingClients.Any(ec => ec.Id == c.Id));
                var newPolicies = policies.Where(p => !existingPolicies.Any(ep => ep.Id == p.Id));

                foreach (var client in newClients)
                {
                    await clientRepository.AddAsync(client);
                }

                foreach (var policy in newPolicies)
                {
                    await policyRepository.AddAsync(policy);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
