using System;

using WorkoutApi.Models;
using Supabase.Postgrest;
using Microsoft.IdentityModel.Tokens;
namespace WorkoutApi.Services
{
    public class EquipmentService
    {
        private readonly SupabaseClientService _supabase;

        public EquipmentService(SupabaseClientService supabase)
        {
            _supabase = supabase;
        }

        public async Task<List<Equipment>?> GetAllEquipments()
        {
            var result = await _supabase.Client
                .From<Equipment>().Get();
            if (result.Models.IsNullOrEmpty())
            {
                return null;
            }
            return result.Models;
        }

        public async Task<Equipment?> GetByName(string name)
        {
            var result = await _supabase.Client
                .From<Equipment>()
                .Filter(x => x.Name, Constants.Operator.ILike, name)
                .Get();

            return result.Models.FirstOrDefault();
        }


        public async Task<Equipment> CreateEquipment(Equipment equipment)
        {
            var response = await _supabase.Client.From<Equipment>().Insert(equipment);
            return response.Models.First();
        }
    }
}
