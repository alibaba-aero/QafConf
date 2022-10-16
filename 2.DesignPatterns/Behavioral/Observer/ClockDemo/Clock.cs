namespace ClockDemo;
public class Clock : IClock
{
    private Time _time = new(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
    private readonly List<IClockObserver> _observers = new();
    public void Attach(IClockObserver clockObserver) => _observers.Add(clockObserver);
    public void Detach(IClockObserver clockObserver) => _observers.Remove(clockObserver);
    public void Notify() => _observers.ForEach(observer => observer.Update(_time));
   
    public void Print()
    {
        var time = GetNow();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{time.Hour:00}:{time.Minute:00}:{time.Second:00}");
        Console.ResetColor();
    }
    
    private Time GetNow()
    {
        Time tickTime = new(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        if (_time.Equals(tickTime) == false)
        {
            _time = tickTime;
            Notify();
        }
        return _time;
    }
}