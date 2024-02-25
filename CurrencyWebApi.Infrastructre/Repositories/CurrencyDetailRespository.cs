using CurrencyWebApi.Domain.Entities;
using CurrencyWebApi.Domain.Repositories;
using CurrencyWebApi.Infrastructre.AppDbContext;

namespace CurrencyWebApi.Infrastructre.Repositories
{
    public class CurrencyDetailRespository : BaseRepository<CurrencyDetail>, ICurrencyDetailRepositroy
    {
        public CurrencyDetailRespository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}