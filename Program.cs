using WorkoutApi.Modules.Swagger;
using WorkoutApi.Domain.Services;


var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SupabaseClientService>();
builder.Services.AddScoped<EquipmentService>();
builder.Services.AddScoped<MuscleService>();
builder.Services.AddScoped<WorkoutService>();
builder.Services.AddControllers();

builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Workout API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

