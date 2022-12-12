using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameService_S3_individueel.Models;

    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int TotalRounds { get; set; }
        public List<string> QuestionIds { get; set; }
        public List<string> CommandIds { get; set; }
        public List<string> PlayerNames { get; set; }
        public string? Winner { get; set; }
    }

