using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TradingDemo.Models;

namespace TradingDemo;

public class CurrencyDataSource
{
    private ConcurrentBag<Currency> Currencies { get; set; }

    public CurrencyDataSource()
    {
        Currencies = new ConcurrentBag<Currency>();
    }

    public void UpdateSource(Currencies currencies)
    {
        AddOrUpdate(currencies.Raw.Ada);
        AddOrUpdate(currencies.Raw.Bnb);
        AddOrUpdate(currencies.Raw.Btc);
        AddOrUpdate(currencies.Raw.Eth);
        AddOrUpdate(currencies.Raw.Sol);
        AddOrUpdate(currencies.Raw.Xrp);
        AddOrUpdate(currencies.Raw.Doge);
    }

    private void AddOrUpdate(Currency currency)
    {
        var item = Currencies
            .FirstOrDefault(x => x.Usd.FromSymbol == currency.Usd.FromSymbol && x.Usd.ToSymbol == currency.Usd.ToSymbol);

        if (item != null)
        {
            item.Usd.IsUp = currency.Usd.Price > item.Usd.Price;
            item.Usd.Price = currency.Usd.Price;
            item.Usd.ToSymbol = currency.Usd.ToSymbol;
            item.Usd.FromSymbol = currency.Usd.FromSymbol;
            item.Usd.HighDay = currency.Usd.HighDay;
            item.Usd.LowDay = currency.Usd.LowDay;
            item.Usd.ImageUrl = currency.Usd.ImageUrl;
        }
        else
            Add(currency);
    }

    private void Add(Currency currency)
    {
        Currencies.Add(currency);
    }

    public List<Currency> Items { get => Currencies.OrderByDescending(x => x.Usd.Price).ToList(); }
}