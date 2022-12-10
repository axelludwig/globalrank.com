namespace GlobalRank.Core.Models.Data
{
    public class QueueData
    {
        public string Name { get; set; }
        public ICollection<RankData> Ranks { get; set; }
    }
}
