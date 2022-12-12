namespace PartyGameAPI.Models
{
    public class Session
    {

        public int Id { get; set; }
        public List<Question> questions = new List<Question>();
        public List<Command> commands = new List<Command>();
        public List<Player> players = new List<Player>();

        public Session()
        {

        }



    }
}
