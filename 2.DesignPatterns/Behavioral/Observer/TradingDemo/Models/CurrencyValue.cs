using Newtonsoft.Json;

namespace TradingDemo.Models;

public class CurrencyValue
{
    [JsonProperty("FROMSYMBOL")]
    public string FromSymbol { get; set; }
    [JsonProperty("TOSYMBOL")]
    public string ToSymbol { get; set; }
    [JsonProperty("PRICE")]
    public decimal Price { get; set; }
    [JsonProperty("HIGHDAY")]
    public decimal HighDay { get; set; }
    [JsonProperty("LOWDAY")]
    public decimal LowDay { get; set; }
    [JsonProperty("IMAGEURL")]
    public string ImageUrl { get; set; }
    public bool IsUp { get; set; }
}