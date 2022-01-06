// using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Configuration;
// using System.Threading;
using App.WindowsService;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
        .UseWindowsService(options =>
        {
            options.ServiceName = "SteamVR Watcher Service";
        })
        .ConfigureServices(services =>
        {
            services.AddHostedService<SteamVRWatcher>();
        })
        .Build();
        await host.RunAsync();
    }
}





