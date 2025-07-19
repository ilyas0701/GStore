
using GameStore.Models.DTO;

namespace GameStore.BLL.Abstract
{
    public interface IGameService
    {
        IEnumerable<GameDto> GetAllGames();
    }
}
