using AutoMapper;
using CurrencyWebApi.Business.Models.DTOs.CurrenctDetailDTOs;
using CurrencyWebApi.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebApi.Domain.Entities;
using CurrencyWebApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CurrencyWebApi.Business.Services.CurrencyDetailsService
{
    public class CurrencyDetailsService : ICurrencyDetailsService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyDetailRepositroy _currencyDetailRepositroy;


        public CurrencyDetailsService(IMapper mapper, ICurrencyDetailRepositroy currencyDetailRepositroy)
        {
            _mapper = mapper;
            _currencyDetailRepositroy = currencyDetailRepositroy;
        }

        public async Task Create(CreateCurrencyDetailDto createCurrencyDetailDto)
        {
            CurrencyDetail currencyDetail = _mapper.Map<CurrencyDetail>(createCurrencyDetailDto);
            await _currencyDetailRepositroy.Add(currencyDetail);
        }

        public async Task<CurrencyDetailVM> GetLastValue(int currebcyId)
        {
            CurrencyDetailVM currencyDetailVM = await _currencyDetailRepositroy.GetFilteredFirstOrDefault(
                select: x => new CurrencyDetailVM()
                {
                    CurrencyName = x.Currency.Name,
                    Value = x.Value
                },
                where : null,
                orderby: x=>x.OrderByDescending(y =>y.Date),
                include: x=>x.Include(y=>y.Currency)
                );

            return currencyDetailVM;
        }
    }
}
