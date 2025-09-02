
using GameStore.BLL.Abstract;
using GameStore.DAL.Abstract;
using GameStore.Models;
using GameStore.Models.DTO;
using GameStore.Utils.Exceptions;

namespace GameStore.BLL
{
    public class GameService(IUnitOfWork unitOfWork) : IGameService
    {
        public async Task<IEnumerable<GameDto>> GetAllGamesAsync(CancellationToken cancellationToken)
        {
            var game = await unitOfWork.GameRepository.GetAsync(cancellationToken);

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

        public async Task CreateGameAsync(GameDto gameDto, CancellationToken cancellationToken)
        {
            var game = new DbGame
            {
                Title = gameDto.Title,
                Description = gameDto.Description,
                Developer = gameDto.Developer,
                Price = gameDto.Price,
                ImgUrl = gameDto.ImgUrl,
                ReleaseAtDate = gameDto.ReleaseAtDate
            };

            unitOfWork.GameRepository.Create(game);
            await unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task<GameDto> GetGameByIdAsync(int id)
        {   
            var game = await unitOfWork.GameRepository.FindById(id);
            
            if (game == null)
            {
                throw new NotFoundException($"Game with id {id} not found.");
            }
            return new GameDto
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Developer = game.Developer,
                Price = game.Price,
                ImgUrl = game.ImgUrl,
                ReleaseAtDate = game.ReleaseAtDate
            };
        }

        public async Task UpdateGameInfo(GameDto gameDto, CancellationToken cancellationToken)
        {
            var game = await unitOfWork.GameRepository.FindById(gameDto.Id);

            if (game == null)
            {
                throw new NotFoundException($"Game with id {gameDto.Id} not found.");
            }

            game.Title = gameDto.Title;
            game.Description = gameDto.Description;
            game.Developer = gameDto.Developer;
            game.Price = gameDto.Price;
            game.ImgUrl = gameDto.ImgUrl;
            game.ReleaseAtDate = gameDto.ReleaseAtDate;

            unitOfWork.GameRepository.Update(game);
            await unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task RemoveGame(int id, CancellationToken cancellationToken)
        {
            var game = await unitOfWork.GameRepository.FindById(id);

            if(game == null)
            {
                throw new NotFoundException($"Game with id {id} not found.");
            }

            unitOfWork.GameRepository.Remove(game);
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
