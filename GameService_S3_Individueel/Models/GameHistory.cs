using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using GameService_S3_individueel.Models;

namespace GameService_S3_Individueel.Models;

public class GameHistory
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string GameId { get; set; }
    public List<string> QuestionIds { get; set; }
    public List<string> CommandIds { get; set; }
    public string Winner { get; set; }
    public DateTime TimeCompleted { get; set; }
    public Game FinishedGame { get; set; }

    public GameHistory()
    {

    }

    public GameHistory(Game game)
    {
        GameId = game.Id;
        QuestionIds = game.QuestionIds;
        CommandIds = game.CommandIds;
        Winner = game.Winner;
        TimeCompleted = DateTime.Now;
        FinishedGame = game;
    }

}
