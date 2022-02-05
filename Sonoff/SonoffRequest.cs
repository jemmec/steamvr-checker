using System;
using System.Text.Json.Serialization;

/// <summary>
/// Base request object
/// </summary>
[Serializable]
public class SonoffRequest
{
    // [JsonPropertyName("deviceid")]
    // public string DeviceId { get; set; }

    [JsonPropertyName("data")]
    public SonoffData Data { get; set; }
}

/// <summary>
/// Switch state enum
/// </summary>
[Serializable]
public enum SwitchState
{
    on=1, off=2
}

[Serializable]
public enum StartupState
{
    stay=1, on=2, off=3
}