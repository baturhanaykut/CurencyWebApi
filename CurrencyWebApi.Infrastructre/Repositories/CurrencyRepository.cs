using CurrencyWebApi.Domain.Entities;
using CurrencyWebApi.Domain.Repositories;
using CurrencyWebApi.Infrastructre.AppDbContext;

namespace CurrencyWebApi.Infrastructre.Repositories
{
    public class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
