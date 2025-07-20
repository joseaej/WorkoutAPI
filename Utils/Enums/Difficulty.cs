using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]

public enum Difficulty
{
    [EnumMember(Value = "Advanced")]
    Advanced,
    [EnumMember(Value = "Intermediate")]
    Intermediate,
    [EnumMember(Value = "Beginner")]
    Beginner,
}