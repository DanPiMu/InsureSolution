using InsureCompany.DomainModel.Entities;
using InsureCompany.DomainModel.RepositoryContracts;
using InsureCompany.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InsureCompany.Infrastructure.RespositoryImplementations
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly AppDbContext _context;

        public PolicyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Policy>> GetAllAsync()
        {
            return await _context.Policies.ToListAsync();
        }

        public async Task<Policy> GetByIdAsync(string id)
        {
            return await _context.Policies.FindAsync(id);
        }
        public async Task<Policy> AddAsync(Policy policies)
        {
            var result = await _context.Policies.AddAsync(policies);
            await _context.SaveChangesAsync();
            return result.Entity;
        }



        public async Task<Client> GetUserByPolicyNumberAsync(string policyNumber)
        {
            var policy = await _context.Policies
                .Where(p => p.Id == policyNumber)
                .FirstOrDefaultAsync();

            if (policy == null)
            {
                return null;
            }

            return await _context.Clients
                .Where(c => c.Id == policy.ClientId)
                .FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<Policy>> GetByUserNameAsync(string userName)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(c => c.Name == userName);
            if (client == null)
            {
                return new List<Policy>();
            }

            return await _context.Policies
                .Where(p => p.ClientId == client.Id)
                .ToListAsync();
        }

        
    }
}
