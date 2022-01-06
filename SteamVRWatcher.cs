using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Diagnostics;

namespace App.WindowsService
{
    public class SteamVRWatcher : BackgroundService
    {

        private const string PROCESS_NAME = "vrmonitor";
        private readonly ILogger<SteamVRWatcher> _logger;
        private bool _isRunning = false;

        public SteamVRWatcher(ILogger<SteamVRWatcher> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Process[] pname = Process.GetProcessesByName(PROCESS_NAME);

                if (pname.Length > 0)
                {
                    if (!_isRunning)
                    {
                        _isRunning = true;
                        _logger.LogInformation("SteamVR Status: Running");
                    }
                }
                else
                {
                    if (_isRunning)
                    {
                        _isRunning = false;
                        _logger.LogInformation("SteamVR Status: Stopped");
                    }
                }
                await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
            }
        }
    }
}