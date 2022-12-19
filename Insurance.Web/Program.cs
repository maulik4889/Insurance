using Insurance.Application;
using Insurance.Infrastructure;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Insurance.Web
{
    public static class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
            .AddEnvironmentVariables()
            .Build();

        public static void Main(string[] args)
        {
            
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                // Add services to the container.
                builder.Services.AddControllers();
                builder.Services.AddInfrastructure(Configuration);
                builder.Services.AddApplication();
                builder.Services.AddMemoryCache();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                var app = builder.Build();
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();
                app.Run();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
    }
}





