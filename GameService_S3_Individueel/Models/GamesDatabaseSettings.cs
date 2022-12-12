namespace GameService_S3_Individueel.Models;

public class GamesDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string GamesCollectionName { get; set; } = null!;
    public string GamesHistoryCollectionName { get; set; } = null!;
}
