
namespace GameStore.DAL
{
    public class SeedHelper
    {
        public static List<T> SeedJsonData<T>(string fileName) where T : class
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "SeedData", $"{fileName}.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Seed data file '{filePath}' not found.");
            }

            var jsonData = File.ReadAllText(filePath);
            return System.Text.Json.JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
        }
    }
}
