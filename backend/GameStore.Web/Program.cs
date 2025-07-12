
using GameStore.DAL;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<GStoreDatabaseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("GStoreConnection")));

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
