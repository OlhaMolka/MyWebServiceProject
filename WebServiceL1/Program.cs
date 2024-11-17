using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebServiceL1
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "API Web Service Project",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Olha Molka",
                        Email = "molkaolga@gmail.com",
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
