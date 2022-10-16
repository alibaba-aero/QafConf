using Newtonsoft.Json;

namespace TradingDemo.Models;

public class Currency
{
    [JsonProperty("USD")]
    public CurrencyValue Usd { get; set; }
}
