<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>Wagner.Framework.WxNLog</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	var service = new NLogBuildService(Util.MyQueriesFolder);
	var host = service.BuildHost(CreateDefaultBuilder);
	UseContainer(host.Services);
}

void UseContainer(IServiceProvider services)
{
	var mainConsole = services.GetRequiredService<MainConsole>();
	mainConsole.DoWork();
}

static IHostBuilder CreateDefaultBuilder(string[] arg)
{
	return Host.CreateDefaultBuilder(arg)
		.ConfigureServices((context, services) =>
		{
			services.AddScoped<MainConsole>();
		});
}

// Define other methods, classes and namespaces here
public class MainConsole
{
	ILogger<MainConsole> _logger;
	public MainConsole(ILogger<MainConsole> logger)
	{
		_logger = logger;
	}
	public void DoWork()
	{
		_logger.LogInformation("DoWork");
	}
}