using System;
using Supabase;
using Supabase.Interfaces;
using System.Text.Json;

namespace WorkoutApi.Services
{
    public class SupabaseClientService
    {
        private readonly Supabase.Client _client;

        public SupabaseClientService(IConfiguration configuration)
        {
            var url = configuration["Supabase:Url"]!;
            var key = configuration["Supabase:Key"]!;

            _client = new Supabase.Client(url, key, new SupabaseOptions
            {
                AutoConnectRealtime = false
            });

            _client.InitializeAsync().Wait();
        }

        public Supabase.Client Client => _client;
    }
}
