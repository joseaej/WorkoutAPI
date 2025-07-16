using Supabase.Postgrest;
using WorkoutApi.Domain.Models;

namespace WorkoutApi.Domain.Services
{
    public class WorkoutService
    {
        private readonly SupabaseClientService _supabase;
        public WorkoutService(SupabaseClientService supabase) => _supabase = supabase;

        public async Task<Workout?> GetWorkoutByName(string name)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x=>x.Name, Constants.Operator.ILike, name).Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<List<Workout>?> GetAllWorkoutsByType(WorkoutType type)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.WorkoutType.ToString(), Constants.Operator.ILike, type.ToString()).Get();
            return result.Models;
        }

        public async Task<List<Workout>?> GetAllWorkoutsByDifficulty(Difficulty difficulty)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.Difficulty.ToString(), Constants.Operator.ILike, difficulty.ToString()).Get();
            return result.Models;
        }

        public async Task<List<Workout>?> GetAllWorkoutsByGoal(WorkoutGoal goal)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.Goal.ToString(), Constants.Operator.ILike, goal.ToString()).Get();
            return result.Models;
        }


        public async Task<Workout> CreateWorkout(Workout workout)
        {
            var result = await _supabase.Client.From<Workout>().Insert(workout);
            return result.Models.First();
        }
    }
}
