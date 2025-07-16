using System;
using Supabase.Postgrest;
using Microsoft.IdentityModel.Tokens;
using WorkoutApi.Domain.Models;

namespace WorkoutApi.Domain.Services
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

        public async Task<Equipment?> UpdateNameEquipment(string oldName , string newName)
        {
            var response = await _supabase.Client.From<Equipment>().Filter(x => x.Name, Constants.Operator.ILike, oldName).Set(x => x.Name,newName).Update();
            return response.Models.FirstOrDefault();
        }

        public async Task<Equipment?> UpdateDescriptionEquipment(string name, string newDescription)
        {
            var response = await _supabase.Client.From<Equipment>().Filter(x => x.Name, Constants.Operator.ILike, name).Set(x => x.Description, newDescription).Update();
            return response.Models.FirstOrDefault();
        }

        public async Task<Equipment> CreateEquipment(Equipment equipment)
        {
            var response = await _supabase.Client.From<Equipment>().Insert(equipment);
            return response.Models.First();
        }
    }
}
