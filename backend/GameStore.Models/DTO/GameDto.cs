
namespace GameStore.Models.DTO
{
    public record GameDto(
        int Id,
        string Title, 
        string Description, 
        string Developer, 
        decimal Price,
        short UnitsInStock,
        bool Discontinued,
        int PublisherId,
        PublisherDto? Publisher,
        string? ImgUrl, 
        DateTime ReleaseAtDate);
}
