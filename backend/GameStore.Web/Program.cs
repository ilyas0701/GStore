
using GameStore.BLL;
using GameStore.BLL.Abstract;
using GameStore.DAL;
using GameStore.DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace GameStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            builder.Services.AddHealthChecks();

            builder.Services.AddDbContext<GStoreDatabaseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("GStoreConnection")));

            // Register BLL services
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IGameService, GameService>();

            var app = builder.Build();

            app.MapHealthChecks("/healthz");

            // Enable OpenAPI and Scalar API
            app.MapOpenApi().CacheOutput();
            app.MapScalarApiReference();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
