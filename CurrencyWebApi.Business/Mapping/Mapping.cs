using AutoMapper;
using CurrencyWebApi.Business.Models.DTOs.CurrenctDetailDTOs;
using CurrencyWebApi.Business.Models.DTOs.CurrencyDTOs;
using CurrencyWebApi.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebApi.Business.Models.VMs.CurrencyVMs;
using CurrencyWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWebApi.Business.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Currency, CreateCurrenycDto>().ReverseMap();
            CreateMap<Currency, UpdateCurrenycDto>().ReverseMap();
            CreateMap<Currency, CurrencyVM>().ReverseMap();

            CreateMap<CurrencyDetail, CreateCurrencyDetailDto>().ReverseMap();
            CreateMap<CurrencyDetail, CurrencyDetailVM>().ReverseMap();

            
        }
    }
}
