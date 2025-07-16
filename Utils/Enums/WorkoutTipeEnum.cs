using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]

public enum WorkoutType
{
    Strength,
    Cardio,
    Endurance,
    Flexibility,
    HIIT,
    Yoga
}
