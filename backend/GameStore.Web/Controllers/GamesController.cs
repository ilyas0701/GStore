using GameStore.BLL.Abstract;
using GameStore.Models.DTO;
using GameStore.Web.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameStore.Web.Controllers
{
    [ApiController]
    [Route("api/v1/games")]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetGames()
        {
            var games = await _gameService.GetAllGamesAsync();

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
        public async Task<IActionResult> CreateGame([FromBody] GameResponse gameResponse, CancellationToken cancellationToken)
        {
            if (gameResponse == null)
            {
                return BadRequest("Game data is null.");
            }

            await _gameService.CreateGameAsync(new GameDto
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
            try
            {
                var game = await _gameService.GetGameByIdAsync(id);
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
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGameInfo([FromBody] GameResponse gameResponse, CancellationToken cancellationToken)
        {
            if (gameResponse == null)
            {
                return BadRequest("Game data is null");
            }

            try
            {
                await _gameService.UpdateGameInfo(new GameDto
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
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveGameInfo([FromBody] int id, CancellationToken cancellationToken)
        {
            try
            {
                await _gameService.RemoveGame(id, cancellationToken);

                return Accepted();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id:int}/comments")]
        public async Task<IActionResult> GetGameComments(int id)
        {
            try
            {
                var comments = await _gameService.GetCommentAsync(id);

                return Ok(comments.Select(r => new CommentResponse
                {
                    Id = r.Id,
                    Name = r.Name,
                    Content = r.Body
                }));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{gameId:int}/newcomment")]
        public async Task<IActionResult> CreateGameComment(int gameId, [FromBody] CommentResponse commentResponse, CancellationToken cancellationToken)
        {
            try
            {
                await _gameService.CreateCommentAsync(new CommentDto
                {
                    Id = commentResponse.Id,
                    Name = commentResponse.Name,
                    Body = commentResponse.Content,
                    GameId = gameId
                }, cancellationToken);

                return CreatedAtAction(nameof(GetGames), commentResponse);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while creating the comment: {ex.Message}");
            }
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
