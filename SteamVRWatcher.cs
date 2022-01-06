using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Diagnostics;
public class SteamVRWatcher: BackgroundService
{

        private const string SERVICE_NAME = "vrmonitor";

        public SteamVRWatcher()
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                Process[] pname = Process.GetProcessesByName(SERVICE_NAME);

                if(pname.Length>0)
                    Console.WriteLine("SteamVR: Running");
                else
                    Console.WriteLine("SteamVR: Closed");

                await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
            }
        }
}