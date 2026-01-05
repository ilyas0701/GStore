
using GameStore.Models.DTO;

namespace GameStore.BLL.Abstract
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetAllGamesAsync(CancellationToken cancellationToken);
        
        Task CreateGameAsync(GameDto gameDto, CancellationToken cancellationToken);

        Task<GameDto> GetGameByIdAsync(int id, CancellationToken cancellationToken);

        Task UpdateGameInfo(GameDto gameDto, CancellationToken cancellationToken);

        Task RemoveGame(int id, CancellationToken cancellationToken);
    }
}
