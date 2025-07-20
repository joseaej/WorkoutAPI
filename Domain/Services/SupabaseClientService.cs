using System;
using Supabase;
using Supabase.Interfaces;
using System.Text.Json;

namespace WorkoutApi.Domain.Services
{
    public class SupabaseClientService
    {
        private readonly Client _client;

        public SupabaseClientService(IConfiguration configuration)
        {
            var url = configuration["Supabase:Url"]!;
            var key = configuration["Supabase:Key"]!;

            _client = new Client(url, key, new SupabaseOptions
            {
                AutoConnectRealtime = false
            });

            _client.InitializeAsync().Wait();
        }

        public Client Client => _client;
    }
}
