using CurrencyWebApi.Business.Models.DTOs.CurrencyDTOs;
using CurrencyWebApi.Business.Services.CurrencyService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrenyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var values = await _currencyService.GetAll();
            return Ok(values);
        }

        [HttpGet("GetCurrencyById")]
        public async Task<IActionResult> GetCurrencyById(int id)
        {
            var values = await _currencyService.GetById(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddCurrency(CreateCurrenycDto createCurrenycDto)
        {
            await _currencyService.Create(createCurrenycDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCurrency(UpdateCurrenycDto updateCurrenycDto)
        {
            await _currencyService.Update(updateCurrenycDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            await _currencyService.Delete(id);
            return Ok();
        }



    }
}
