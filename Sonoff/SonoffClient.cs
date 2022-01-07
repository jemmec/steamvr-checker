using System;
using System.Net.Http;
using System.Text.Json;

/// <summary>
/// Simple and hacky REST api for sonoff 
/// </summary>
public class SonoffClient
{

    protected HttpClient _client;

    public SonoffClient()
    {
        _client = new HttpClient();
    }

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

        var body = default(SonoffResponse);
        HttpResponseMessage res = null;
        HttpRequestException err = null;
        try
        {
            res = await _client.PostAsync(device.GetUri() + "switch",
            new StringContent(
               JsonSerializer.Serialize(request,
               new JsonSerializerOptions
               {
                   DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault
               })
            ));

            if (res.IsSuccessStatusCode)
            {
                string resContent = await res.Content.ReadAsStringAsync();
                body = JsonSerializer.Deserialize<SonoffResponse>(resContent);
            }
            else
                throw new HttpRequestException(res.StatusCode.ToString());
        }
        catch (HttpRequestException e)
        {
            err = e;
        }
        finally
        {
            callback(err, res, body);
        }
    }
}