using InsureCompany.DomainModel.Entities;
using InsureCompany.DomainModel.RepositoryContracts;
using InsureCompany.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InsureCompany.Infrastructure.RespositoryImplementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(string id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> AddAsync(Client client)
        {
            var result = await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Client> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetByUserNameAsync(string userName)
        {
            return await _context.Clients.Where(c => c.Name == userName).FirstOrDefaultAsync();
        }
    }
}
