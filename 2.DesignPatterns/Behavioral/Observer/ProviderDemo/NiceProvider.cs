namespace TicketDemo;

public class NiceProvider : IProvider
{
    private List<IConsumer> Consumers { get; set; } = new();
    private List<AvailableService> AvailableServices { get; set; } = new();
    
    public void Attach(IConsumer consumer) => Consumers.Add(consumer);
    public void Detach(IConsumer consumer) => Consumers.Remove(consumer);

    public void Notify(AvailableService availableService) 
        => Consumers.ForEach(consumer => consumer.Update(availableService));

    public void AddNewService(AvailableService availableService)
    {
        var exist = AvailableServices.Any(x => x.ServiceCode == availableService.ServiceCode);
        if (exist == false)
        {
            AvailableServices.Add(availableService);
            Notify(availableService);
        }
    }

    public void UpdateServicePrice(UpdateServiceCommand updateCommand)
    {
        var target = AvailableServices
            .SingleOrDefault(x => x.ServiceCode == updateCommand.ServiceCode);

        if (target != null)
        {
            AvailableServices.Remove(target);
            target.Price = updateCommand.Price;
            AvailableServices.Add(target);
            Notify(target);
        }
    }
}