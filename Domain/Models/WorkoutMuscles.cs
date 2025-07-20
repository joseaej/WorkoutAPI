using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace WorkoutApi.Domain.Models
{
    [Table("workout_muscles")]
    public class WorkoutMuscles:BaseModel
    {
        [PrimaryKey("id",false)]
        public Guid ID{ get; set; }
        [Column("workout_id")]
        public Guid WorkoutID { get; set; }
        [Column("muscle_id")]
        public Guid MusclesID { get; set; }

        public WorkoutMuscles() { }
        public WorkoutMuscles(Guid workoutID,Guid muscleID) {
            WorkoutID = workoutID;
            MusclesID = muscleID;
        }

    }
}
