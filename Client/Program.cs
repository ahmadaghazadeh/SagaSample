// See https://aka.ms/new-console-template for more information
Console.Title = "Client";

var configuration = new EndpointConfiguration("Client");
configuration.UseTransport<LearningTransport>();

var bus = await Endpoint.Start(configuration).ConfigureAwait(false);

Console.WriteLine("Bus Started!");
Console.WriteLine();