namespace TicketDemo;

public interface IProvider
{
    void Attach(IConsumer consumer);
    void Detach(IConsumer consumer);
    void Notify(AvailableService availableService);

    void AddNewService(AvailableService availableService);
    void UpdateServicePrice(UpdateServiceCommand updateCommand);
}