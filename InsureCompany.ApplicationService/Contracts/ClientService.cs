using InsureCompany.ApplicationService.Service;
using InsureCompany.DomainModel.Entities;
using InsureCompany.DomainModel.RepositoryContracts;
using InsureCompany.Infrastructure.RespositoryImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureCompany.ApplicationService.Contracts
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        private readonly IPolicyRepository _policyRepository;

        public ClientService(IClientRepository clientRepository, IPolicyRepository policyRepository)
        {
            _clientRepository = clientRepository;
            _policyRepository = policyRepository;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<Client> GetClientByIdAsync(string id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            return await _clientRepository.AddAsync(client);
        }


        public async Task<Client> GetClientByNameAsync(string name)
        {
            return await _clientRepository.GetByUserNameAsync(name);
        }

        public async Task<Client> GetClientByPolicyNumberAsync(string policyNumber)
        {
            return await _policyRepository.GetUserByPolicyNumberAsync(policyNumber);
        }

    }
}
