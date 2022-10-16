using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using TradingDemo.Services;

namespace TradingDemo
{
    public partial class MainWindow : Window
    {
        private readonly CurrencyDataSource _currencyDataSource;
        private readonly CurrencyTracker _currencyTracker;
        private readonly PeriodicTimer timer;
        private CurrencyReporter _currencyReporter;
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();

        public MainWindow(CurrencyDataSource currencyDataSource, CurrencyTracker currencyTracker)
        {
            InitializeComponent();
            _currencyDataSource = currencyDataSource;
            _currencyTracker = currencyTracker;
            timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            LoadAction();
        }

        private void LoadAction()
        {
            _currencyReporter = new CurrencyReporter(_currencyDataSource);
            _currencyTracker.Subscribe(_currencyReporter);

            _backgroundWorker.DoWork += worker_DoWork;
            _backgroundWorker.RunWorkerAsync();
        }

        private async void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                await _currencyTracker.TrackAsync();
                await Dispatcher.InvokeAsync(() =>
                {
                    lst_summary.ItemsSource = _currencyDataSource.Items
                        .Select(x => new CurrencyListItemViewModel
                        {
                            FromSymbol = x.Usd.FromSymbol,
                            ToSymbol = x.Usd.ToSymbol,
                            LowDay = x.Usd.LowDay,
                            HighDay = x.Usd.HighDay,
                            Price = x.Usd.Price,
                            ImageUrl = x.Usd.ImageUrl,
                            IsUp = x.Usd.IsUp ? "+" : "-"
                        });
                    lst_summary.Items.Refresh();
                });
            }
            while (await timer.WaitForNextTickAsync());
        }
    }
}