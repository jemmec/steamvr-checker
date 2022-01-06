using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        var host = new HostBuilder()
        .ConfigureHostConfiguration(configHost => {

        })
        .ConfigureServices((hostContext, services) => {
            services.AddHostedService<SteamVRWatcher>();
        })
        .UseConsoleLifetime()
        .Build();
        host.Run();
    }
}

