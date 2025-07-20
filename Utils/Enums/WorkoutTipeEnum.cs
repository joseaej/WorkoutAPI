using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]

public enum WorkoutType
{
    [EnumMember(Value = "Strength")]
    Strength,
    [EnumMember(Value = "Cardio")]
    Cardio,
    [EnumMember(Value = "Endurance")]
    Endurance,
    [EnumMember(Value = "Flexibility")]
    Flexibility,
    [EnumMember(Value = "HIIT")]
    HIIT,
    [EnumMember(Value = "Yoga")]
    Yoga
}
