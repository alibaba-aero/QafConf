using Newtonsoft.Json;

namespace TradingDemo.Models;

public class Currencies
{
    [JsonProperty("RAW")]
    public CurrenciesView Raw { get; set; }
}
