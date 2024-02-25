using CurrencyWebApi.Domain.Entities;
using CurrencyWebApi.Infrastructre.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CurrencyWebApi.Infrastructre.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyDetail> CurrenyDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyConfig())
                .ApplyConfiguration(new CurrencyDetailConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
