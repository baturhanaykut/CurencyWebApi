using AutoMapper;
using CurrencyWebApi.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebApi.Business.Models.VMs.CurrencyVMs;
using CurrencyWebApi.Business.Services.CurrencyService;
using CurrencyWebApi.Domain.Entities;
using CurrencyWebApi.Domain.Repositories;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

namespace CurrencyWebApi.Business.Services.CurrencyDetailsService
{
    public class CurrencyDetailsService : ICurrencyDetailsService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyDetailRepositroy _currencyDetailRepositroy;
        private readonly ICurrencyService _currencyService;


        public CurrencyDetailsService(IMapper mapper, ICurrencyDetailRepositroy currencyDetailRepositroy, ICurrencyService currencyService)
        {
            _mapper = mapper;
            _currencyDetailRepositroy = currencyDetailRepositroy;
            _currencyService = currencyService;
        }

        public async Task Create()
        {
            List<CurrencyVM> currencies = await _currencyService.GetAll();

            HtmlWeb web = new HtmlWeb();
            var doc = web.Load("https://www.doviz.com/");
            var docNode = doc.DocumentNode;

            List<CurrencyDetail>currencyDetails = new List<CurrencyDetail>();

            foreach (CurrencyVM currency in currencies)
            {
                CurrencyDetail currencyDetail = new CurrencyDetail();
                currencyDetail.CurrenyId = currency.Id;
                currencyDetail.Date = DateTime.Now;
                currencyDetail.Value = docNode.SelectSingleNode($"//span[@data-socket-key='{currency.AttributeName}' and @data-socket-attr='s']").InnerText;
                currencyDetails.Add(currencyDetail);
            }

            await _currencyDetailRepositroy.AddRange(currencyDetails);
        }

        public async Task<CurrencyDetailVM> GetLastValue(int currencyId)
        {
            CurrencyDetailVM currencyDetailVM = await _currencyDetailRepositroy.GetFilteredFirstOrDefault(
                select: x => new CurrencyDetailVM()
                {
                    CurrencyName = x.Currency.Name,
                    Value = x.Value
                },
                where : x=>x.CurrenyId == currencyId,
                orderby: x=>x.OrderByDescending(y =>y.Date),
                include: x=>x.Include(y=>y.Currency)
                );

            return currencyDetailVM;
        }

        public async Task<List<CurrencyDetailVM>> GetLastValue()
        {
            List<CurrencyVM> currencies = await _currencyService.GetAll();

            List<CurrencyDetailVM> currencyDetails = new List<CurrencyDetailVM>();
            foreach (CurrencyVM currency in currencies)
            {
                currencyDetails.Add(await GetLastValue(currency.Id));
            }

            return currencyDetails;
        }
    }
}
