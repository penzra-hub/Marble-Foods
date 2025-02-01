using MarbleFoods.Infrastructure.Seeder;
using MarbleFoods.Presentation.Middlewares;

namespace AgroCommodityIMS.Application
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddInfrastructureServices(builder.Configuration, builder.Logging);
            var app = builder.Build();

            // configure http pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            await SeederClass.SeedData(app);

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseCors();

            // Custom Authentication Header
            app.UseMiddleware<CustomJwtAuthentication>();
            app.UseAuthentication();
            app.UseAuthorization();

            //Global Exception Header
            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.MapControllers();
            app.Run();
        }
    }
}