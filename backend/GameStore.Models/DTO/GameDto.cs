
namespace GameStore.Models.DTO
{
    public record GameDto(
        int Id,
        string Title, 
        string Description, 
        string Developer, 
        decimal Price, 
        string? ImgUrl, 
        DateTime ReleaseAtDate);
}
