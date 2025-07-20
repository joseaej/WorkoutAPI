using WorkoutApi.Domain.Models;

namespace WorkoutApi.Domain.DTOs
{
    public class WorkoutMusclesDto
    {
        public Guid ID { get; set; }
        public Guid WorkoutID { get; set; }
        public Guid MusclesID { get; set; }


        public WorkoutMusclesDto(WorkoutMuscles workoutMuscles)
        {
            ID = workoutMuscles.ID;
            WorkoutID = workoutMuscles.WorkoutID;
            MusclesID = workoutMuscles.MusclesID;
        }
    }
}
