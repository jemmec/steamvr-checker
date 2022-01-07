using System;
using System.Text.Json.Serialization;
/// <summary>
/// Base class for the data object
/// </summary>
[Serializable]
public class SonoffData
{
    [JsonPropertyName("switch"), JsonConverter(typeof(JsonStringEnumConverter))]
    public SwitchState Switch { get; set; }

    [JsonPropertyName("startup"), JsonConverter(typeof(JsonStringEnumConverter))]
    public StartupState Startup { get; set; }

    [JsonPropertyName("pulse"), JsonConverter(typeof(JsonStringEnumConverter))]
    public SwitchState Pulse { get; set; }

    [JsonPropertyName("pulseWidth")]
    public int? PulseWidth { get; set; }

    [JsonPropertyName("signalStrength")]
    public int? SignalStrength { get; set; }

}
