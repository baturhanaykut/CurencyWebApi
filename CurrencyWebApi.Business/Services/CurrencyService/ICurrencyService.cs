using CurrencyWebApi.Business.Models.DTOs.CurrencyDTOs;
using CurrencyWebApi.Business.Models.VMs.CurrencyVMs;

namespace CurrencyWebApi.Business.Services.CurrencyService
{
    public interface ICurrencyService
    {
        Task Create(CreateCurrenycDto createCurrenycDto);

        Task Update(UpdateCurrenycDto updateCurrenycDto);

        Task Delete(int id);

        Task<CurrencyVM> GetById(int id);

        Task<List<CurrencyVM>> GetAll();
    }
}
