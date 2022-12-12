using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameService_S3_individueel.Models;

public class GameHistoryModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string GameId { get; set; }
    public List<string> QuestionIds { get; set; }
    public List<string> CommandIds { get; set; }
    public string Winner { get; set; }
    public DateTime TimeCompleted { get; set; }
    public GameModel FinishedGame { get; set; }

    public GameHistoryModel()
    {

    }

    public GameHistoryModel(GameModel game)
    {
        GameId = game.Id;
        QuestionIds = game.QuestionIds;
        CommandIds = game.CommandIds;
        Winner = game.Winner;
        TimeCompleted = DateTime.Now;
        FinishedGame = game;
    }
}

