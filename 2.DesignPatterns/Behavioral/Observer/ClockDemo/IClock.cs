namespace ClockDemo;

public interface IClock
{
    void Attach(IClockObserver clockObserver);
    void Detach(IClockObserver clockObserver);
    void Notify();
    void Print();
}