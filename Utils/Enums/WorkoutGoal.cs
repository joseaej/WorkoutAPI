using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WorkoutGoal
{
    [EnumMember(Value = "Hypertrophy")]
    Hypertrophy,
    [EnumMember(Value = "FatLoss")]
    FatLoss,
    [EnumMember(Value = "Strength")]
    Strength,
    [EnumMember(Value = "Endurance")]
    Endurance,
    [EnumMember(Value = "Flexibility")]
    Flexibility,
    [EnumMember(Value = "General Fitness")]
    GeneralFitness,
    [EnumMember(Value = "Rehabilitation")]
    Rehabilitation
}
