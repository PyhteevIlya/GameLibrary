using GameLibrary.Core.Abstractions;
using GameLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _repository;

        public GameController(IGameRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(nameof(GetGames))]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            var response = await _repository.Get();
            return Ok(response);
        }
        [HttpGet(nameof(GetGameById))]
        public async Task<ActionResult<Game>> GetGameById(Guid id)
        {
            var games = await _repository.Get();
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpGet(nameof(GetGamesByGenre))]
        public async Task<ActionResult<List<Game>>> GetGamesByGenre(string genre)
        { 
            var games = await _repository.Get();
            var response = games.Where(g => g.Genres.Contains(genre)).ToList();
            return Ok(response);
        }

        [HttpPost(nameof(CreateGame))]
        public async Task<IActionResult> CreateGame(Game request)
        {
            var gamesId = await _repository.Create(request);
            return Ok(gamesId);
        }

        [HttpPut("UpdateGame/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateGame(Guid id, Game request)
        {
            var gamesId = await _repository.Update(id, request.Name, request.Genres, request.GameDeveloper);
            return Ok(gamesId);
        }

        [HttpDelete("DeleteGame/{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteGame(Guid id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
