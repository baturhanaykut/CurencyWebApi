using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWebApi.Domain.Entities
{
    public class CurrencyDetail
    {
        public int CurrenyId { get; set; }

        public DateTime Date { get; set; }

        public string? Value { get; set; }

        public Currency Currency { get; set; }
    }
}
