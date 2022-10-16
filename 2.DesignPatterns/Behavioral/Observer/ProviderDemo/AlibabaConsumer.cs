namespace TicketDemo;

public class AlibabaConsumer : IConsumer
{
    private List<AvailableService> AvailableServices { get; set; } = new();
    
    public void Update(AvailableService availableService)
    {
        var target = AvailableServices
            .FirstOrDefault(x => x.ServiceCode != null && x.ServiceCode.Equals(availableService.ServiceCode));
        
        if (target != null)
        {
            AvailableServices.Remove(target);
            AvailableServices.Add(availableService);
        }
        else
        {
            AvailableServices.Add(availableService);
        }
    }
    
    public void PrintServices()
    {
        var splitter = new string('*', 64);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(splitter);
        Console.WriteLine("Alibaba Services");
        if (AvailableServices.Any() == false)
            Console.WriteLine($"EMPTY");

        AvailableServices.ForEach(x =>
        {
            Console.WriteLine($"{x.OriginCode}-{x.DestinationCode}\t{x.DepartureDate.ToString("yyyy-MM-dd hh:mm:ss")}\t{x.Price:C0}");
        });
        Console.WriteLine(splitter);
        Console.ResetColor();
    }
}