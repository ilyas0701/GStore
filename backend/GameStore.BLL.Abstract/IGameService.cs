
using GameStore.Models.DTO;

namespace GameStore.BLL.Abstract
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetAllGamesAsync();
    }
}
