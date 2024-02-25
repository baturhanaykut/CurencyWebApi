using AutoMapper;
using CurrencyWebApi.Business.Models.DTOs.CurrencyDTOs;
using CurrencyWebApi.Business.Models.VMs.CurrencyVMs;
using CurrencyWebApi.Domain.Entities;
using CurrencyWebApi.Domain.Repositories;

namespace CurrencyWebApi.Business.Services.CurrencyService
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(IMapper mapper, ICurrencyRepository currencyRepository)
        {
            _mapper = mapper;
            _currencyRepository = currencyRepository;
        }

        public async Task Create(CreateCurrenycDto createCurrenycDto)
        {
            bool hasCurrency = await  _currencyRepository.Any(x => x.Name == createCurrenycDto.Name);
            if (!hasCurrency)
            {
                Currency currency = _mapper.Map<Currency>(createCurrenycDto);
                await _currencyRepository.Add(currency);
            }
            
        }

        public async Task Delete(int id)
        {
            Currency currency = await _currencyRepository.GetDefault(x => x.Id == id);
            if (currency is not null)
            {
                await _currencyRepository.Add(currency);
            }
        }

        public async Task<List<CurrencyVM>> GetAll()
        {
            List<Currency> currencies = await _currencyRepository.GetDefaults(x =>x.Name != null);
            List<CurrencyVM> currencisVM = _mapper.Map<List<CurrencyVM>>(currencies);
            return currencisVM;
        }

        public async Task<CurrencyVM> GetById(int id)
        {
            Currency currency = await _currencyRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<CurrencyVM> (currency); 
        }

        public async Task Update(UpdateCurrenycDto updateCurrenycDto)
        {
            Currency currency = _mapper.Map<Currency>(updateCurrenycDto);
            await _currencyRepository.Update(currency);
        }
    }
}
