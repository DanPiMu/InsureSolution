using InsureCompany.ApplicationService.Service;
using InsureCompany.DomainModel.Entities;
using InsureCompany.DomainModel.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureCompany.ApplicationService.Contracts
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;

        public PolicyService(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public async Task<IEnumerable<Policy>> GetAllAsync()
        {
            return await _policyRepository.GetAllAsync();
        }

        public async Task<Policy> GetByIdAsync(string id)
        {
            return await _policyRepository.GetByIdAsync(id);
        }

        public async Task<Policy> AddAsync(Policy policy)
        {
            return await _policyRepository.AddAsync(policy);
        }


        public async Task<IEnumerable<Policy>> GetPoliciesByUserNameAsync(string userName)
        {
            return await _policyRepository.GetByUserNameAsync(userName);
        }
    }
}
