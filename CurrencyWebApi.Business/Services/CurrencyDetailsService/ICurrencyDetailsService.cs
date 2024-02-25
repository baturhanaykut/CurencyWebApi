using CurrencyWebApi.Business.Models.DTOs.CurrenctDetailDTOs;
using CurrencyWebApi.Business.Models.DTOs.CurrencyDTOs;
using CurrencyWebApi.Business.Models.VMs.CurrencyDetailVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWebApi.Business.Services.CurrencyDetailsService
{
    public interface ICurrencyDetailsService
    {
        Task Create(CreateCurrencyDetailDto createCurrencyDetailDto);

        Task<CurrencyDetailVM> GetLastValue(int currebcyId);
    }
}
