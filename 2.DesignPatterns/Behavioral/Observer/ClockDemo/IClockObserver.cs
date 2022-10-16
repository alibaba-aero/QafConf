namespace ClockDemo;

public interface IClockObserver
{
    void Update(Time time);
    void Print();
}