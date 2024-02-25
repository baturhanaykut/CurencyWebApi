using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWebApi.Domain.Entities
{
    public class CurrenyDetail
    {
        public int CurrenyId { get; set; }

        public DateTime Date { get; set; }

        public string? Value { get; set; }

        public List<Currency>? Currencies { get; set; }
    }
}
