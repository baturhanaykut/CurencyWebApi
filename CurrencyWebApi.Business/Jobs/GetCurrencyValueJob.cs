using CurrencyWebApi.Business.Services.CurrencyDetailsService;
using Quartz;

namespace CurrencyWebApi.Business.Jobs
{
    public class GetCurrencyValueJob: IJob
    {
        private readonly ICurrencyDetailsService _currencyDetailsService;

        public GetCurrencyValueJob(ICurrencyDetailsService currencyDetailsService)
        {
            _currencyDetailsService = currencyDetailsService;
        }


        public async Task Execute(IJobExecutionContext context)
        {
            await _currencyDetailsService.Create();

        }
    }
}
