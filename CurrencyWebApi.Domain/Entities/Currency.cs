namespace CurrencyWebApi.Domain.Entities
{
    public class Currency
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? AttributeName { get; set; }

        public List<CurrencyDetail> CurrencyDetails { get; set; }
    }
}
