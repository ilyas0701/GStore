
using GameStore.BLL;
using GameStore.BLL.Abstract;
using GameStore.DAL;
using GameStore.DAL.Abstract;
using GameStore.Web.Middleware;
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
            builder.Services.AddScoped<ICommentService, CommentService>();

            var app = builder.Build();
            
            app.MapHealthChecks("/healthz");

            app.UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseMiddleware<ExceptionHandlingMiddleware>();
            
            // Enable OpenAPI and Scalar API
            app.MapOpenApi().CacheOutput();
            app.MapScalarApiReference();

            app.MapControllers();

            app.Run();
        }
    }
}
