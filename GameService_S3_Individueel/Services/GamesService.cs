using GameService_S3_individueel.Models;
using GameService_S3_Individueel.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GameService_S3_Individueel.Services;

public class GamesService
{
    private readonly IMongoCollection<Game> _gamesCollection;
    private readonly IMongoCollection<GameHistory> _gamesHistoryCollection;

    public GamesService(
        IOptions<GamesDatabaseSettings> gamesDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            gamesDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            gamesDatabaseSettings.Value.DatabaseName);

        _gamesCollection = mongoDatabase.GetCollection<Game>(
            gamesDatabaseSettings.Value.GamesCollectionName);

        _gamesHistoryCollection = mongoDatabase.GetCollection<GameHistory>(
            gamesDatabaseSettings.Value.GamesHistoryCollectionName);
    }

    public async Task<List<Game>> GetGameAsync() =>
        await _gamesCollection.Find(_ => true).ToListAsync();

    public async Task<Game?> GetGameAsync(string id) =>
        await _gamesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateGameAsync(Game newGame) =>
        await _gamesCollection.InsertOneAsync(newGame);

    public async Task UpdateGameAsync(string id, Game updateGame) =>
        await _gamesCollection.ReplaceOneAsync(x => x.Id == id, updateGame);

    public async Task DeleteGameAsync(string id) =>
        await _gamesCollection.DeleteOneAsync(x => x.Id == id);

}
