using InsureCompany.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureCompany.DomainModel.RepositoryContracts
{
    public interface IPolicyRepository
    {
        Task<IEnumerable<Policy>> GetAllAsync();
        Task<Policy> GetByIdAsync(string id);
        Task<Policy> AddAsync(Policy policy);


        Task<IEnumerable<Policy>> GetByUserNameAsync(string userName);
        Task<Client> GetUserByPolicyNumberAsync(string policyNumber);
    }
}
