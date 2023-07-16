using InsureCompany.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;


namespace InsureCompany.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Policy> Policies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Role).IsRequired();
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.AmountInsured).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.InceptionDate).IsRequired();
                entity.Property(e => e.InstallmentPayment).IsRequired();
                entity.Property(e => e.ClientId).IsRequired();
            });
        }
    }
}
