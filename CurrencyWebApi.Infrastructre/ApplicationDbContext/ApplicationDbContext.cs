using CurrencyWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyWebApi.Infrastructre.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrenyDetail> CurrenyDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyConfig())
                .ApplyConfiguration(new CurrencyDetailConfig());

                base.OnModelCreating(modelBuilder);
        }
    }
}
