using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TradingDemo.Models;

namespace TradingDemo.Services;

public class CurrencyClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    private const string RequestUrl = "https://min-api.cryptocompare.com/data/pricemultifull" +
                                      "?fsyms=BTC,ETH,USDT,USDC,BNB,XRP,BUSD,ADA,SOL,DOGE&tsyms=USD";

    public CurrencyClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    public async Task<Currencies> GetCurrenciesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync(RequestUrl, cancellationToken);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

            var result = JsonConvert.DeserializeObject<Currencies>(responseContent);
            return result;
        }
        catch (Exception)
        {
            return new Currencies();
        }
    }
}