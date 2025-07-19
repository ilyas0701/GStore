
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
        public IEnumerable<GameDto> GetAllGames()
        {
            return _unitOfWork.GameRepository.Get().Select(g => new GameDto
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
