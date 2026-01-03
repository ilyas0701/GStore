namespace GameStore.Web.Models.Responses
{
    public record GameResponse(int Id, 
        string Title, 
        string Description, 
        string Developer, 
        decimal Price, 
        string? ImgUrl, 
        DateTime ReleaseAtDate);
}
 