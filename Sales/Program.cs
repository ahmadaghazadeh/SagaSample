// See https://aka.ms/new-console-template for more information

using NServiceBus.Persistence.Sql;
using System.Data.SqlClient;

Console.Title = "Sales";


//await RunScript(GetConnectionString());



var configuration = new EndpointConfiguration("Sales");

var persistence = configuration.UsePersistence<SqlPersistence>();
persistence.SqlDialect<SqlDialect.MsSqlServer>();
persistence.ConnectionBuilder(
	connectionBuilder: () => new SqlConnection(GetConnectionString()));
var subscriptions = persistence.SubscriptionSettings();
subscriptions.CacheFor(TimeSpan.FromMinutes(1));

configuration.UseTransport<LearningTransport>();

var bus = await Endpoint.Start(configuration).ConfigureAwait(false);


Console.WriteLine("Bus Started!");
Console.WriteLine();

async Task RunScript(string s)
{
	await ScriptRunner.Install(
		sqlDialect: new SqlDialect.MsSqlServer(),
		tablePrefix: "Sales",
		connectionBuilder: () => new SqlConnection(s),
		scriptDirectory: AppContext.BaseDirectory +@"NServiceBus.Persistence.Sql\MsSqlServer",
		shouldInstallOutbox: true,
		shouldInstallSagas: true,
		shouldInstallSubscriptions: true,
		cancellationToken: CancellationToken.None);
}

static  string GetConnectionString()
{
	// To avoid storing the connection string in your code,
	// you can retrieve it from a configuration file.
	return @"Data Source=.;Initial Catalog=Saga;User Id=sa;Password=Pass@word;"
		   + "Integrated Security=FALSE;";
}

 