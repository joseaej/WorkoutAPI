using WorkoutApi.Domain.Models;

namespace WorkoutApi.Domain.DTOs
{
    public class WorkoutDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public WorkoutType WorkoutType { get; set; }
        public WorkoutGoal Goal { get; set; }
        public Difficulty Difficulty { get; set; }
        public int TotalDuration { get; set; }
        public int EstimatedCalories { get; set; }
        public string VideoURL { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public WorkoutDto(Workout workout)
        {
            Id = workout.Id;
            Name = workout.Name;
            Description = workout.Description;
            WorkoutType = workout.WorkoutType;
            Goal = workout.Goal;
            Difficulty = workout.Difficulty;
            TotalDuration = workout.TotalDuration;
            EstimatedCalories = workout.EstimatedCalories;
            VideoURL = workout.VideoURL;
            ImageURL = workout.ImageURL;
            CreatedAt = workout.CreatedAt;
        }
    }
}
