using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWebApi.Business.Models.DTOs.CurrenctDetailDTOs
{
    public class CreateCurrencyDetailDto
    {
        public int CurrenyId { get; set; }

        public DateTime Date { get; set; }

        public string? Value { get; set; }
    }
}
