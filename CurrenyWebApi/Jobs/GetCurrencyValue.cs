using CurrencyWebApi.Business.Services.CurrencyDetailsService;
using Quartz;

namespace CurrenyWebApi.Jobs
{
    public class GetCurrencyValue : IJob
    {
        private readonly ICurrencyDetailsService _currencyDetailsService;

        public GetCurrencyValue(ICurrencyDetailsService currencyDetailsService)
        {
            _currencyDetailsService = currencyDetailsService;
        }


        public async Task Execute(IJobExecutionContext context)
        {
           await _currencyDetailsService.Create();
      
        }
    }
}
