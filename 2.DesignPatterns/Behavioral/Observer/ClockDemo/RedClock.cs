namespace ClockDemo;

public class RedClock : IClockObserver
{
    private Time? _currentTime;
    public void Update(Time time) => _currentTime = time;

    public void Print()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{_currentTime?.Hour:00}:{_currentTime?.Minute:00}:{_currentTime?.Second:00}");
        Console.ResetColor();
    }
}