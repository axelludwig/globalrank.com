namespace GlobalRank.Core.Models.Data
{
    public class GameData
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public ICollection<QueueData> Queues { get; set; }
    }
}