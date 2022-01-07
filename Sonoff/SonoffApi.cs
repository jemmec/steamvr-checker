using System;
using System.Net.Http;

/// <summary>
/// Simple and hacky REST api for sonoff 
/// </summary>
public class SonoffApi
{


    /// <summary>
    /// Switches the Sonoff device on or off
    /// </summary>
    /// <param name="device"></param>
    /// <param name="on"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public async void Switch(SonoffDevice device, SwitchState state, Action<HttpRequestException, HttpResponseMessage, SonoffResponse> callback)
    {
        SonoffRequest request = new SonoffRequest
        {
            DeviceId = device.Id,
            Data = new SonoffData
            {
                Switch = state
            }
        };
        



    }



}