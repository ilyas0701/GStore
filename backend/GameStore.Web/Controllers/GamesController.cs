using GameStore.BLL.Abstract;
using GameStore.Models.DTO;
using GameStore.Web.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace GameStore.Web.Controllers
{
    [ApiController]
    [Route("api/v1/games")]
    public class GamesController(
        IGameService gameService, 
        ICommentService commentService,
        IOutputCacheStore outputCacheStore) : Controller
    {
        [HttpGet]
        [OutputCache(Duration = 60, Tags = ["games-list"])]
        public async Task<IActionResult> GetGames(CancellationToken cancellationToken)
        {
            var games = await gameService.GetAllGamesAsync(cancellationToken);

            var response = games.Select(g => new GameResponse
            (
                g.Id,
                g.Title,
                g.Description,
                g.Developer,
                g.Price,
                g.ImgUrl,
                g.ReleaseAtDate
            ));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] GameResponse? gameResponse, CancellationToken cancellationToken)
        {
            if (gameResponse == null)
            {
                return BadRequest("Game data is null.");
            }

            await gameService.CreateGameAsync(new GameDto
            (
                0,
                gameResponse.Title,
                gameResponse.Description,
                gameResponse.Developer,
                gameResponse.Price,
                gameResponse.ImgUrl,
                gameResponse.ReleaseAtDate
            ), cancellationToken);


            await outputCacheStore.EvictByTagAsync("games-list", cancellationToken);

            return CreatedAtAction(nameof(GetGames), new { id = gameResponse.Id }, gameResponse);
        }

        [HttpGet("{id:int}")]
        [OutputCache(Duration = 60)]
        public async Task<IActionResult> GetGameById(int id, CancellationToken cancellationToken)
        {
            var game = await gameService.GetGameByIdAsync(id, cancellationToken);

            var response = new GameResponse
            (
                game.Id,
                game.Title,
                game.Description,
                game.Developer,
                game.Price,
                game.ImgUrl,
                game.ReleaseAtDate
            );

            HttpContext.Response.Headers.Append("Cache-Tag", $"game-{id}");

            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGameInfo(int id, [FromBody] GameResponse gameResponse, CancellationToken cancellationToken)
        {
            await gameService.UpdateGameInfo(new GameDto
            (
                id,
                gameResponse.Title,
                gameResponse.Description,
                gameResponse.Developer,
                gameResponse.Price,
                gameResponse.ImgUrl,
                gameResponse.ReleaseAtDate
            ), cancellationToken);

            await outputCacheStore.EvictByTagAsync("games-list", cancellationToken);
            await outputCacheStore.EvictByTagAsync($"game-{id}", cancellationToken);

            return Accepted();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveGameInfo(int id, CancellationToken cancellationToken)
        {
            await gameService.RemoveGame(id, cancellationToken);

            await outputCacheStore.EvictByTagAsync("games-list", cancellationToken);
            await outputCacheStore.EvictByTagAsync($"game-{id}", cancellationToken);

            return Accepted();
        }

        [HttpGet("{id:int}/comments")]
        public async Task<IActionResult> GetGameComments(int id, CancellationToken cancellationToken)
        {
            var comments = await commentService.GetCommentAsync(id, cancellationToken);

            return Ok(comments);
        }

        [HttpPost("{id:int}/comments")]
        public async Task<IActionResult> CreateGameComment(int id, [FromBody] CommentResponse commentResponse, CancellationToken cancellationToken)
        {
            await commentService.CreateCommentAsync(new CommentDto(
                commentResponse.Id,
                id,
                commentResponse.ParentId,
                commentResponse.Name,
                commentResponse.Content,
                new List<CommentDto>()
            ), cancellationToken);

            return CreatedAtAction(nameof(GetGameComments), new { id }, commentResponse);
        }

        [HttpGet("{id:int}/download")]
        public IActionResult DownloadGame(int id)
        {
            var content = $"Game ID: {id}\nDownloaded at: {DateTime.UtcNow}";

            var bytes = System.Text.Encoding.UTF8.GetBytes(content);

            var fileName = $"game_{id}.txt";

            return File(bytes, "text/plain", fileName);
        }
    }
}
