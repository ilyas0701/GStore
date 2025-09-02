using GameStore.BLL.Abstract;
using GameStore.Models.DTO;
using GameStore.Web.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controllers
{
    [ApiController]
    [Route("api/v1/games")]
    public class GamesController(IGameService gameService, ICommentService commentService) : Controller
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetGames(CancellationToken cancellationToken)
        {
            var games = await gameService.GetAllGamesAsync(cancellationToken);

            var response = games.Select(g => new GameResponse
            {
                Id = g.Id,
                Title = g.Title,
                Description = g.Description,
                Developer = g.Developer,
                Price = g.Price,
                ImgUrl = g.ImgUrl,
                ReleaseAtDate = g.ReleaseAtDate
            });

            return Ok(response);
        }

        [HttpPost("new")]
        public async Task<IActionResult> CreateGame([FromBody] GameResponse? gameResponse, CancellationToken cancellationToken)
        {
            if (gameResponse == null)
            {
                return BadRequest("Game data is null.");
            }

            await gameService.CreateGameAsync(new GameDto
            {
                Title = gameResponse.Title,
                Description = gameResponse.Description,
                Developer = gameResponse.Developer,
                Price = gameResponse.Price,
                ImgUrl = gameResponse.ImgUrl,
                ReleaseAtDate = gameResponse.ReleaseAtDate
            }, cancellationToken);

            return CreatedAtAction(nameof(GetGames), new { id = gameResponse.Id }, gameResponse);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            var game = await gameService.GetGameByIdAsync(id);
            
            var response = new GameResponse
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Developer = game.Developer,
                Price = game.Price,
                ImgUrl = game.ImgUrl,
                ReleaseAtDate = game.ReleaseAtDate
            };
            
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGameInfo([FromBody] GameResponse gameResponse, CancellationToken cancellationToken)
        {
            await gameService.UpdateGameInfo(new GameDto
            {
                Id = gameResponse.Id,
                Title = gameResponse.Title,
                Description = gameResponse.Description,
                Developer = gameResponse.Developer,
                Price = gameResponse.Price,
                ImgUrl = gameResponse.ImgUrl,
                ReleaseAtDate = gameResponse.ReleaseAtDate
            }, cancellationToken);

            return Accepted();
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveGameInfo([FromBody] int id, CancellationToken cancellationToken)
        {
            await gameService.RemoveGame(id, cancellationToken);

            return Accepted();
        }

        [HttpGet("{id:int}/comments")]
        public async Task<IActionResult> GetGameComments(int id, CancellationToken cancellationToken)
        {
            var comments = await commentService.GetCommentAsync(id, cancellationToken);

            return Ok(comments?.Select(r => new CommentResponse
            {
                Id = r.Id,
                Name = r.Name,
                Content = r.Body
            }));
        }

        [HttpPost("{gameId:int}/new-comment")]
        public async Task<IActionResult> CreateGameComment(int gameId, [FromBody] CommentResponse commentResponse, CancellationToken cancellationToken)
        {
            await commentService.CreateCommentAsync(new CommentDto
            {
                Id = commentResponse.Id,
                Name = commentResponse.Name,
                Body = commentResponse.Content,
                GameId = gameId
            }, cancellationToken);

            return Ok(commentResponse);
        }

        [HttpGet("{gameId:int}/download")]
        public IActionResult DownloadGame(int gameId)
        {
            var content = $"Game ID: {gameId}\nDownloaded at: {DateTime.UtcNow}";

            var bytes = System.Text.Encoding.UTF8.GetBytes(content);

            var fileName = $"game_{gameId}.txt";

            return File(bytes, "text/plain", fileName);
        }
    }
}
