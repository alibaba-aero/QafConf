using ClockDemo;

var clock = new Clock();
var redClock = new RedClock();
var greenClock = new GreenClock();
clock.Attach(redClock);
clock.Attach(greenClock);

//--------------------------------------------

var splitter = new string('*', 32);
var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
while (await timer.WaitForNextTickAsync())
{
    Console.Clear();
    Console.WriteLine("Clock Observer");
    Console.WriteLine(splitter);
    clock.Print();
    Console.WriteLine(splitter);
    greenClock.Print();
    Console.WriteLine(splitter);
    redClock.Print();
}