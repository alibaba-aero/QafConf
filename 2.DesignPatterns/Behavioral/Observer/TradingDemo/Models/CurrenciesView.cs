using Newtonsoft.Json;

namespace TradingDemo.Models;

public class CurrenciesView
{
    [JsonProperty("BTC")]
    public Currency Btc { get; set; }
    [JsonProperty("ETH")]
    public Currency Eth { get; set; }
    [JsonProperty("ADA")]
    public Currency Ada { get; set; }
    [JsonProperty("BNB")]
    public Currency Bnb { get; set; }
    [JsonProperty("XRP")]
    public Currency Xrp { get; set; }
    [JsonProperty("SOL")]
    public Currency Sol { get; set; }
    [JsonProperty("DOGE")]
    public Currency Doge { get; set; }
}