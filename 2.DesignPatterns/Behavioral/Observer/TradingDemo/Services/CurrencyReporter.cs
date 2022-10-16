using TradingDemo.Models;

namespace TradingDemo.Services;

public class CurrencyReporter : IObserver<Currencies>
{
    private readonly CurrencyDataSource _currencyDataSource;

    public CurrencyReporter(CurrencyDataSource currencyDataSource)
    {
        _currencyDataSource = currencyDataSource;
    }

    public void OnCompleted()
        => Console.WriteLine($"Completed");

    public void OnError(Exception error) 
        => Console.WriteLine($"Could not handle currencies. details: {error?.Message}");

    public void OnNext(Currencies value) => _currencyDataSource.UpdateSource(value);
}