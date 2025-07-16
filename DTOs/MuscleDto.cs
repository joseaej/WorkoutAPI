using WorkoutApi.Models;

namespace WorkoutApi.DTOs
{
    public class MuscleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }

        public MuscleDto(Muscle muscle)
        {
            Id = muscle.Id;
            Name = muscle.Name;
            Description = muscle.Description;
            CreateAt = muscle.CreateAt;
        }
    }
}
