namespace GameStore.Models;

public class DbPublisher
{
    public int Id { get; set; }
    public required string CompanyName { get; set; }
    public string? Description { get; set; }
    public string? HomePage { get; set; }
    public List<DbGame> Games { get; set; } = [];
}
