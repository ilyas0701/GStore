using GameStore.BLL.Abstract;
using GameStore.Models.DTO;
using GameStore.Web.Models.Responses;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
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
    }
}
