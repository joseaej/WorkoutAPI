using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]

public enum Difficulty
{
    Hard,
    Medium,
    Easy,
}