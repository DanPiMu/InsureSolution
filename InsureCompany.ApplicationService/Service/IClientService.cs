using InsureCompany.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureCompany.ApplicationService.Service
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(string id);
        Task<Client> AddClientAsync(Client client);

        Task<Client> GetClientByPolicyNumberAsync(string policyNumber);
        Task<Client> GetClientByNameAsync(string name);


    }

}
