
using GameStore.BLL.Abstract;
using GameStore.DAL.Abstract;
using GameStore.Models.DTO;

namespace GameStore.BLL
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GameDto>> GetAllGamesAsync()
        {
            var game = await _unitOfWork.GameRepository.GetAsync();

            return game.Select(g => new GameDto
            {
                Id = g.Id,
                Title = g.Title,
                Description = g.Description,
                Developer = g.Developer,
                Price = g.Price,
                ImgUrl = g.ImgUrl,
                ReleaseAtDate = g.ReleaseAtDate 
            });
        }
    }
}
