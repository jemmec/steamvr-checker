using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Diagnostics;

namespace App.WindowsService
{
    /// <summary>
    /// A background service for turning Sonoff Devices on or off when
    /// SteamVR starts / closes on a windows PC
    /// </summary>
    public class SteamVRWatcher : BackgroundService
    {
        private const double POLLING_SECONDS = 5;
        private const string PROCESS_NAME = "vrmonitor";
        private readonly ILogger<SteamVRWatcher> _logger;
        private bool _isRunning = false;

        private SonoffClient _sonoffClient;
        private SonoffDevices _devices;


        public SteamVRWatcher(ILogger<SteamVRWatcher> logger)
        {
            _logger = logger;
            _sonoffClient = new SonoffClient();

            //TODO: Change this to auto discovery or some other better way
            //Pull Sonoff devices from a JSON file 

            _devices = new SonoffDevices
            {
                Devices = new SonoffDevice[]{
                    new SonoffDevice{
                        Id ="",
                        IpAddress = "192.162.2.2",
                        Port = "8081"
                    }
                }
            };

        }

        private void SwitchDevices(SwitchState state)
        {
            //Turn devices on
            foreach (SonoffDevice device in _devices.Devices)
            {
                _sonoffClient.Switch(device, state, (err, message, res) =>
                {
                    if (err != null)
                        _logger.LogError(err.Message);
                    else
                        _logger.LogInformation("Succesfully turned " + state.ToString() + " device " + device.IpAddress);
                });
            }
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
                        _logger.LogInformation("SteamVR Status: Started");
                        SwitchDevices(SwitchState.on);
                    }
                }
                else
                {
                    if (_isRunning)
                    {
                        _isRunning = false;
                        _logger.LogInformation("SteamVR Status: Stopped");
                        SwitchDevices(SwitchState.off);
                    }
                }
                await Task.Delay(TimeSpan.FromSeconds(POLLING_SECONDS), stoppingToken);
            }
        }
    }
}