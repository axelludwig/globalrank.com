namespace GlobalRank.Core.Models
{
    public class GameData
    {
        public string Name { get; set; }
        public ICollection<LeagueData> Leagues { get; set; }
    }
}