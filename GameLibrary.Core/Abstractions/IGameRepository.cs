using GameLibrary.Core.Models;

namespace GameLibrary.Core.Abstractions;

public interface IGameRepository
{
    Task<List<Game>> Get();
    Task<Guid> Create(Game game);
    Task<Guid> Update(Guid id, string name, string[] genres, string gameDeveloper);
    Task<Guid> Delete(Guid id);
}