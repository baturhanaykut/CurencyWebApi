using CurrencyWebApi.Business.Services.CurrencyDetailsService;
using Microsoft.AspNetCore.Mvc;

namespace CurrenyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyDetailController : ControllerBase
    {
        private readonly ICurrencyDetailsService _currencyDetailsService;

        public CurrencyDetailController(ICurrencyDetailsService currencyDetailsService)
        {
            _currencyDetailsService = currencyDetailsService;
        }


        [HttpPost("AddCurrencyDetail")]
        public async Task<IActionResult> AddCurrencyDetail()
        {
            await _currencyDetailsService.Create();
            return Ok();
        }

        [HttpGet(" GetLastValueOfCurrencies")]
        public async Task<IActionResult> GetLastValueOfCurrencies()
        {
            var values = await _currencyDetailsService.GetLastValue();
            return Ok(values);
        }


    }
}
