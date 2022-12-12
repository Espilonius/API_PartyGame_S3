using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Bson;
using GameService_S3_individueel.Models;
using GameService_S3_Individueel.Services;

namespace GameService_S3_individueel.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly GamesService _gamesService;

    public GamesController(GamesService gamesService) =>
        _gamesService = gamesService;

    // GET: api/Games
    [HttpGet]
    public async Task<List<Game>> GetGame() =>
        await _gamesService.GetGameAsync();

    // GET: api/Games/5
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Game>> GetGame(string id)
    {
        var game = await _gamesService.GetGameAsync(id);

        if (game is null)
        {
            return NotFound();
        }

        return game;
    }

    // POST: api/Games
    [HttpPost]
    public async Task<IActionResult> PostGame(Game newGame)
    {
        await _gamesService.CreateGameAsync(newGame);

        return CreatedAtAction(nameof(GetGame), new { id = newGame.Id }, newGame);
    }

    // Put: api/Games/5
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> UpdateGame(string id, Game updatedGame)
    {
        var game = await _gamesService.GetGameAsync(id);

        if (game is null)
        {
            return NotFound();
        }

        updatedGame.Id = game.Id;

        await _gamesService.UpdateGameAsync(id, updatedGame);

        return NoContent();
    }

    // Delete: api/Games/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(string id)
    {
        var game = await _gamesService.GetGameAsync(id);

        if (game is null)
        {
            return NotFound();
        }

        await _gamesService.DeleteGameAsync(id);

        return NoContent();
    }
}
