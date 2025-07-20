
using GameStore.BLL.Abstract;
using GameStore.DAL.Abstract;
using GameStore.Models;
using GameStore.Models.DTO;
using System.IO;
using System.Text;

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

            _unitOfWork.GameRepository.Create(game);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task<GameDto> GetGameByIdAsync(int id)
        {
            var game = await _unitOfWork.GameRepository.FindById(id);
            if (game == null)
            {
                throw new KeyNotFoundException($"Game with id {id} not found.");
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
            var game = await _unitOfWork.GameRepository.FindById(gameDto.Id);

            if (game == null)
            {
                throw new KeyNotFoundException($"Game with id {gameDto.Id} not found.");
            }

            game.Title = gameDto.Title;
            game.Description = gameDto.Description;
            game.Developer = gameDto.Developer;
            game.Price = gameDto.Price;
            game.ImgUrl = gameDto.ImgUrl;
            game.ReleaseAtDate = gameDto.ReleaseAtDate;

            _unitOfWork.GameRepository.Update(game);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task RemoveGame(int id, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.FindById(id);

            if(game == null)
            {
                throw new KeyNotFoundException($"Game with id {id} not found.");
            }

            _unitOfWork.GameRepository.Remove(game);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task CreateCommentAsync(CommentDto commentDto, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.FindById(commentDto.GameId);
            
            if (game == null)
            {
                throw new KeyNotFoundException($"Game with id {commentDto.GameId} not found.");
            }

            var comment = new DbComment
            {
                GameId = commentDto.GameId,
                Name = commentDto.Name,
                Body = commentDto.Body,
                Game = game
            };

            _unitOfWork.CommentRepository.Create(comment);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentAsync(int gameId)
        {
            var game = await _unitOfWork.GameRepository.FindById(gameId);

            if (game == null)
            {
                throw new KeyNotFoundException($"Game with id {gameId} not found.");
            }

            var comments = await _unitOfWork.CommentRepository.GetAsync(c => c.GameId == gameId);

            if (comments == null || !comments.Any())
            {
                throw new KeyNotFoundException($"No comments found for game with id {gameId}.");
            }

            return comments.Select(c => new CommentDto
            {
                Id = c.Id,
                GameId = c.GameId,
                Name = c.Name,
                Body = c.Body
            });
        }
    }
}
