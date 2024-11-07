using GameLibrary.Core.Abstractions;
using GameLibrary.Core.Models;
using GameLibrary.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.DataAccess.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameLibraryDbContext _context;

        public GameRepository(GameLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> Get()
        {
            var gameEntitys = await _context.Games
                .AsNoTracking()
                .ToListAsync();
            var game = gameEntitys
            .Select(b =>
                    new Game
                        (b.Id, b.Name, b.Genres, b.GameDeveloper))
                .ToList();

            return game;
        }

        public async Task<Guid> Create(Game game)
        {
            var gameEntity = new GameEntity()
            {
                Id = game.Id,
                Name = game.Name,
                Genres = game.Genres,
                GameDeveloper = game.GameDeveloper,
            };
            await _context.Games.AddAsync(gameEntity);
            await _context.SaveChangesAsync();

            return gameEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string[] genres, string gameDeveloper)
        {
            var gameEntity = await _context.Games
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, name)
                    .SetProperty(b => b.Genres, genres)
                    .SetProperty(b => b.GameDeveloper, gameDeveloper));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Games
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
