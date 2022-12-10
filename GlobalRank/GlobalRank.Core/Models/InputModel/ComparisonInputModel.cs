namespace GlobalRank.Core.Models.InputModel
{
    public class ComparisonInputModel
    {
        public string MyGameId { get; set; }
        public string MyQueue { get; set; }
        public string MyRank { get; set; }
        public ICollection<ComparisonGameInputModel> Queues { get; set; }
    }
}
