// See https://aka.ms/new-console-template for more information
Console.Title = "Inventory";

var configuration = new EndpointConfiguration("Inventory");
configuration.UseTransport<LearningTransport>();

var bus = await Endpoint.Start(configuration).ConfigureAwait(false);

Console.WriteLine("Bus Started!");
Console.WriteLine();