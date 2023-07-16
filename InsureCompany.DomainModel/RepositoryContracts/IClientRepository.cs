using InsureCompany.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureCompany.DomainModel.RepositoryContracts
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(string id);
        Task<Client> AddAsync(Client client);


        //Task<Client> GetByUserIdAsync(string userId);
        Task<Client> GetByUserNameAsync(string userName);
    }
}
