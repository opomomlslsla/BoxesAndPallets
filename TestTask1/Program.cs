using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using BoxesAndPallets.Domain.Interfaces;
using BoxesAndPallets.Services;

namespace BoxesAndPallets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddScoped<IBoxFactory, BoxFactory>()
                            .AddScoped<IPalletFactory, PalletFactory>()
                            .AddScoped<MainService>();
                })
                .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();

            var service = ActivatorUtilities.GetServiceOrCreateInstance<MainService>(host.Services);
            service.Run();
        }
    }
}
