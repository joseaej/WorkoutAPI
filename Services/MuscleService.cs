using Microsoft.IdentityModel.Tokens;
using Supabase.Postgrest;
using WorkoutApi.Models;

namespace WorkoutApi.Services
{
    public class MuscleService
    {
        private readonly SupabaseClientService _supabase;

        public MuscleService(SupabaseClientService supabase) => _supabase = supabase;

        public async Task<Muscle?> GetMuscleByName(string name)
        {
            var result = await _supabase.Client.From<Muscle>().Filter(x=> x.Name, Constants.Operator.ILike,name).Get();
            return result.Models.FirstOrDefault();
            
        }
        public async Task<List<Muscle>?> GetAllMuscles()
        {
            var result = await _supabase.Client
                .From<Muscle>().Get();
            if (result.Models.IsNullOrEmpty())
            {
                return null;
            }
            return result.Models;

        }
        public async Task<Muscle> CreateMuscle(Muscle muscle)
        {
            var response = await _supabase.Client.From<Muscle>().Insert(muscle);
            return response.Models.First();
        }
    }
 }

