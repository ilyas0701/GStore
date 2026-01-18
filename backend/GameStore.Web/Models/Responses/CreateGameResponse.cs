namespace GameStore.Web.Models.Responses
{
    public record CreateGameResponse(int Id,
        string Title,
        string Description,
        string Developer,
        decimal Price,
        short UnitsInStock,
        bool Discontinued,
        int PublisherId,
        string? ImgUrl,
        DateTime ReleaseAtDate);
}
