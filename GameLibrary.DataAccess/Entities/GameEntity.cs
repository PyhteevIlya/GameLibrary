namespace GameLibrary.DataAccess.Entities
{
    public class GameEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string[] Genres { get; set; }
        public string GameDeveloper { get; set; }
    }
}
