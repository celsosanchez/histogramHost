using HostExample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

internal class Program
{
    public static IHost App { get; private set; }
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World! creating host builder for services");
        App = CreateHostBuilder(args).Build();
        new SomeLogic().TellTheTime();
        var coso = App.Services.GetService<AServiceConsumer>();
        App.Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
           .ConfigureServices((hostContext, services) =>
           {
               services.AddTransient<AService>();
               services.AddTransient<AServiceConsumer>();
           });
}