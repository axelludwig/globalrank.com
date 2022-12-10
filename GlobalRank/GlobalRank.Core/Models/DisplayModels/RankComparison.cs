namespace GlobalRank.Core.Models.DisplayModels
{
    public class RankComparison
    {
        public RankGameComparison MyGame { get; set; }
        public ICollection<RankGameComparison> OtherGames { get; set; } = new List<RankGameComparison>();
    }
}
