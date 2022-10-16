namespace TradingDemo
{
    public class CurrencyListItemViewModel
    {
        public string FromSymbol { get; set; }
        public string ToSymbol { get; set; }
        public decimal Price { get; set; }
        public decimal HighDay { get; set; }
        public decimal LowDay { get; set; }
        public string ImageUrl { get; set; }
        public string IsUp { get; set; }
    }
}
