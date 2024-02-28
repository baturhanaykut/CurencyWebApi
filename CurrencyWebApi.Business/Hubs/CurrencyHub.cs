using CurrencyWebApi.Business.Services.CurrencyDetailsService;
using Microsoft.AspNetCore.SignalR;

namespace CurrencyWebApi.Business.Hubs
{
    public class CurrencyHub : Hub
    {
        private readonly ICurrencyDetailsService _currencyDetailsService;

        public CurrencyHub(ICurrencyDetailsService currencyDetailsService)
        {
            _currencyDetailsService = currencyDetailsService;
        }

        public async Task SendCurrentCurrencyValue()
        {
            await Clients.All.SendAsync("CurrentCurrencyValue", await _currencyDetailsService.GetLastValue());
        }
    }
}
