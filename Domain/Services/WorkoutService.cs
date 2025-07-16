using WorkoutApi.Domain.Models;

namespace WorkoutApi.Domain.Services
{
    public class WorkoutService
    {
        private readonly SupabaseClientService _supabase;
        public WorkoutService(SupabaseClientService supabase) => _supabase = supabase;

        public async Task<Workout> CreateWorkout(Workout workout)
        {
            var result = await _supabase.Client.From<Workout>().Insert(workout);
            return result.Models.First();
        }
    }
}
