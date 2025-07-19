
using GameStore.Models.DTO;

namespace GameStore.BLL.Abstract
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetAllGamesAsync();
        
        Task CreateGameAsync(GameDto gameDto, CancellationToken cancellationToken);

        Task<GameDto> GetGameByIdAsync(int id);

        Task UpdateGameInfo(GameDto gameDto, CancellationToken cancellationToken);

        Task RemoveGame(GameDto gameDto, CancellationToken cancellationToken);
    }
}
