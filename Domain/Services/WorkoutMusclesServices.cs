using WorkoutApi.Domain.Models;

namespace WorkoutApi.Domain.Services
{
    public class WorkoutMusclesServices
    {
        private readonly SupabaseClientService _supabase;

        public WorkoutMusclesServices(SupabaseClientService supabase) => _supabase = supabase;


        public async Task<List<Muscle>?> GetAllMusclesForWorkout(string workoutName)
        {
            var workout = await _supabase.Client
                .From<Workout>()
                .Filter(x => x.Name, Supabase.Postgrest.Constants.Operator.ILike, workoutName)
                .Get();

            if (workout.Model == null) return null;

            var workoutList = await _supabase.Client
                .From<WorkoutMuscles>()
                .Filter(x => x.WorkoutID, Supabase.Postgrest.Constants.Operator.Equals, workout.Model!.Id.ToString())
                .Get();
            List<Muscle>? muscles = new List<Muscle>();
            foreach (var item in workoutList.Models)
            {
                var muscle = await _supabase.Client
                .From<Muscle>()
                .Filter(x => x.Id, Supabase.Postgrest.Constants.Operator.Equals, item.MusclesID.ToString())
                .Get();
                if (muscle.Model == null) continue;
                muscles.Add(muscle.Model!);
            }
            return muscles;
        }
        public async Task<bool?> DeleteAMuscleForWorkout(string workoutName,string muscleName)
        {
            var workout = await _supabase.Client
                .From<Workout>()
                .Filter(x => x.Name, Supabase.Postgrest.Constants.Operator.ILike, workoutName)
                .Get();

            if (workout.Model == null) return null;

            var muscle = await _supabase.Client
                .From<Muscle>()
                .Filter(x => x.Name, Supabase.Postgrest.Constants.Operator.ILike, muscleName)
                .Get();

            if (muscle.Model == null) return null;

            var deleteItem = await _supabase.Client
                .From<WorkoutMuscles>()
                .Filter(x => x.WorkoutID, Supabase.Postgrest.Constants.Operator.Equals, workout.Model!.Id.ToString())
                .Filter(x => x.MusclesID, Supabase.Postgrest.Constants.Operator.Equals, muscle.Model!.Id.ToString())
                .Get();
            if (deleteItem.Model == null) return null;
            await _supabase.Client.From<WorkoutMuscles>().Delete(deleteItem.Model);
            return true;


        }
        public async Task<List<Workout>?> GetAllWorkoutsForMuscle(string muscleName)
        {
            var muscle = await _supabase.Client
                .From<Muscle>()
                .Filter(x => x.Name, Supabase.Postgrest.Constants.Operator.ILike, muscleName)
                .Get();

            if (muscle.Model == null) return null;

            var muscleList = await _supabase.Client
                .From<WorkoutMuscles>()
                .Filter(x => x.MusclesID, Supabase.Postgrest.Constants.Operator.Equals, muscle.Model!.Id.ToString())
                .Get();

            List<Workout>? workouts = new List<Workout>();

            foreach (var item in muscleList.Models)
            {
                var workout = await _supabase.Client
                .From<Workout>()
                .Filter(x => x.Id, Supabase.Postgrest.Constants.Operator.Equals, item.WorkoutID.ToString())
                .Get();
                if (workout.Model == null) continue;
                workouts.Add(workout.Model!);
            }
            return workouts;
        }

        public async Task<List<WorkoutMuscles>> CreateMusclesForWorkout(string workoutName, List<string> muscleNames)
        {
            List<WorkoutMuscles> workoutMuscles = new List<WorkoutMuscles>();

            // Buscar el ID del workout por nombre (iLike)
            Guid? workout = (await _supabase.Client
                .From<Workout>()
                .Filter(x => x.Name, Supabase.Postgrest.Constants.Operator.ILike, workoutName)
                .Select(x => new object[] { x.Id })
                .Get()).Model?.Id;

            if (workout == null) return new List<WorkoutMuscles>();

            Console.WriteLine($"Workout ID: {workout}");

            foreach (var muscleName in muscleNames)
            {
                // Buscar el ID del músculo por nombre (iLike)
                Guid? muscle = (await _supabase.Client
                    .From<Muscle>()
                    .Filter(x => x.Name, Supabase.Postgrest.Constants.Operator.ILike, muscleName)
                    .Select(x => new object[] { x.Id })
                    .Get()).Model?.Id;

                if (muscle == null) continue;

                Console.WriteLine($"Muscle ID: {muscle}");

                // Comprobar si la relación ya existe
                var existing = await _supabase.Client
                    .From<WorkoutMuscles>()
                    .Filter(x => x.WorkoutID, Supabase.Postgrest.Constants.Operator.Equals, workout.Value.ToString())
                    .Filter(x => x.MusclesID, Supabase.Postgrest.Constants.Operator.Equals, muscle.Value.ToString())
                    .Get();

                if (existing.Models.Count > 0)
                {
                    Console.WriteLine($"La relación Workout:{workout} - Muscle:{muscle} ya existe. Se omite.");
                    continue;
                }

                // Insertar si no existe
                var result = await _supabase.Client
                    .From<WorkoutMuscles>()
                    .Insert(new WorkoutMuscles(workout.Value, muscle.Value));

                if (result != null)
                {
                    workoutMuscles.Add(result.Model!);
                }
            }

            return workoutMuscles;
        }

    }
}
