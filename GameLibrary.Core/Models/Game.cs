namespace GameLibrary.Core.Models
{
    public class Game
    {
        public Game(Guid id, string name, string[] genres, string gameDeveloper)
        {
            Id = id;
            Name = name;
            Genres = genres;
            GameDeveloper = gameDeveloper;
        }
        public Guid Id { get; }
        public string Name { get; }
        public string[] Genres { get; }
        public string GameDeveloper { get; }
    }
}
