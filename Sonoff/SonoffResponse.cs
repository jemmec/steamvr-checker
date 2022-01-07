using System;
using System.Text.Json.Serialization;

/// <summary>
/// Base request object
/// </summary>
[Serializable]
public class SonoffResponse
{
    [JsonPropertyName("seq")]
    public int Sequence { get; set; }

    [JsonPropertyName("error")]
    public int Error { get; set; }

    [JsonPropertyName("data")]
    public SonoffData Data { get; set; }
}



