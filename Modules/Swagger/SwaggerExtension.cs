using Microsoft.OpenApi.Models;

namespace WorkoutApi.Modules.Swagger
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // Define the Swagger document
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Workout API - Swagger UI",
                    Description = "API for managing workout equipment and routines.",
                    Contact = new OpenApiContact
                    {
                        Name = "joseaej",
                        Url = new Uri("https://github.com/joseaej")
                    },
                });

                // Include XML comments from XML docs (if generated)
                var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly);
                foreach (var xmlFile in xmlFiles)
                {
                    c.IncludeXmlComments(xmlFile);
                }
            });

            return services;
        }
    }
}
