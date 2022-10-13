namespace TicketDemo;

public record AvailableService
{
    public AvailableService(string? serviceCode, string? originCode, 
        string? destinationCode, DateTime departureDate, decimal price)
    {
        ServiceCode = serviceCode;
        OriginCode = originCode;
        DestinationCode = destinationCode;
        DepartureDate = departureDate;
        Price = price;
    }

    public string? ServiceCode { get; set; }
    public string? OriginCode { get; set; }
    public string? DestinationCode { get; set; }
    public DateTime DepartureDate { get; set; }
    public decimal Price { get; set; }
};