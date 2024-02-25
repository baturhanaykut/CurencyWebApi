using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWebApi.Business.Models.DTOs.CurrencyDTOs
{
    public class CreateCurrenycDto
    {
        public  string? Name{ get; set; }

        public string? AttributeName { get; set; }
    }
}
