using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWebApi.Business.Models.VMs.CurrencyVMs
{
    public class CurrencyVM
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? AttributeName { get; set; }
    }
}
