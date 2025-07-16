using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]

public enum WorkoutType
{
    Fuerza,
    Cardio,
    Resistencia,
    Flexibilidad,
    HIIT,
    Yoga
}