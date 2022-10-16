using System.Collections.Generic;
using System.Threading.Tasks;
using TradingDemo.Models;

namespace TradingDemo.Services;

public class CurrencyTracker : IObservable<Currencies>
{
    private readonly List<IObserver<Currencies>> _observers;
    private readonly CurrencyClient _currencyClient;

    public CurrencyTracker(CurrencyClient currencyClient)
    {
        _currencyClient = currencyClient;
        _observers = new List<IObserver<Currencies>>();
    }

    public IDisposable Subscribe(IObserver<Currencies> observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);

        return new Unsubscriber(_observers, observer);
    }

    private class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<Currencies>> _observers;
        private readonly IObserver<Currencies> _observer;

        public Unsubscriber(List<IObserver<Currencies>> observers, IObserver<Currencies> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }

    public async Task TrackAsync()
    {
        var currencies = await _currencyClient.GetCurrenciesAsync();
        foreach (var observer in _observers)
        {
            if (currencies != null)
                observer.OnNext(currencies);
            else
                observer.OnError(new Exception());
        }
    }
}