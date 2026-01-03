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

            builder.Services.AddHsts(options =>
            {
                options.MaxAge = TimeSpan.FromDays(365);
                options.IncludeSubDomains = true;
                options.Preload = true;
            });

            builder.Services.AddOutputCache();

            var app = builder.Build();

            app.MapHealthChecks("/healthz");

            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseOutputCache();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GStoreDatabaseContext>();
                context.Database.Migrate();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>()
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization();
            
            // Enable OpenAPI and Scalar API
            app.MapOpenApi().CacheOutput();
            app.MapScalarApiReference();

            app.MapControllers();

            app.Run();
        }
    }
}
