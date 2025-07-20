using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace WorkoutApi.Domain.Models
{
    [Table("workouts")]
    public class Workout : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("type")]
        public string WorkoutType { get; set; }

        [Column("goal")]
        public string Goal { get; set; }

        [Column("level_difficulty")]
        public string Difficulty { get; set; }

        [Column("total_duration")]
        public int TotalDuration { get; set; }

        [Column("estimated_calories")]
        public int EstimatedCalories { get; set; }

        [Column("url_video")]
        public string VideoURL { get; set; }

        [Column("url_image")]
        public string ImageURL { get; set; }

        [Column("create_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Workout() { }
        public Workout(string name, string description, string workoutType, string goal, string difficulty, int totalDuration, int estimatedCalories, string videoURL, string imageURL)
        {
            Name = name;
            Description = description;
            WorkoutType = workoutType;
            Goal = goal;
            Difficulty = difficulty;
            TotalDuration = totalDuration;
            EstimatedCalories = estimatedCalories;
            VideoURL = videoURL;
            ImageURL = imageURL;
        }
    }
}