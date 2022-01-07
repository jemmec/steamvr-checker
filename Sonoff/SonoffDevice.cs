using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class SonoffDevices
{
    [JsonPropertyName("devices")]
    public SonoffDevice[] Devices { get; set; }
}

[Serializable]
public class SonoffDevice
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("ipAddress")]
    public string IpAddress { get; set; }

    [JsonPropertyName("port")]
    public string Port { get; set; }
}