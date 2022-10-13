using TicketDemo;

var niceProvider = new NiceProvider();
var alibabaConsumer = new AlibabaConsumer();
niceProvider.Attach(alibabaConsumer);

alibabaConsumer.PrintServices();

niceProvider.AddNewService(new AvailableService("123","THR","MHD",DateTime.Now.AddHours(4), 12));
niceProvider.AddNewService(new AvailableService("456","THR","MHD",DateTime.Now.AddHours(6), 12));
niceProvider.AddNewService(new AvailableService("789","THR","MHD",DateTime.Now.AddHours(8), 12));

alibabaConsumer.PrintServices();

niceProvider.UpdateServicePrice(new UpdateServiceCommand("456", 14));

alibabaConsumer.PrintServices();

