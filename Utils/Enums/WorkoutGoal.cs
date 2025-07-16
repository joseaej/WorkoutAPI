using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WorkoutGoal
{
    Hypertrophy,        // Hipertrofia
    FatLoss,            // Pérdida de grasa
    Strength,           // Fuerza
    Endurance,          // Resistencia
    Flexibility,        // Flexibilidad
    GeneralFitness,     // Fitn ess general
    MuscleTone,         // Tonificación muscular
    Rehabilitation      // Rehabilitación
}
