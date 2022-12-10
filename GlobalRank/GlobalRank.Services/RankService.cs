using GlobalRank.Core.Interfaces.Repositories;
using GlobalRank.Core.Interfaces.Services;
using GlobalRank.Core.Models.Data;
using GlobalRank.Core.Models.DisplayModels;
using GlobalRank.Core.Models.InputModel;

namespace GlobalRank.Services
{
    public class RankService : IRankService
    {
        private readonly IRankRepository Repository;

        public RankService(IServiceProvider serviceProvider)
        {
            Repository = serviceProvider.GetService(typeof(IRankRepository)) as IRankRepository;
        }

        public ICollection<GameData> GetData()
        {
            return Repository.GetData();
        }

        public RankComparison CompareRanks(ComparisonInputModel comparisonInputModel)
        {
            RankComparison res = new();

            IEnumerable<GameData> games = GetData();

            GameData myGame = games.FirstOrDefault(x => x.Id == comparisonInputModel.MyGameId);

            QueueData myQueue = myGame.Queues.FirstOrDefault(x => x.Name == comparisonInputModel.MyQueue);

            RankData myRank = myQueue.Ranks.FirstOrDefault(x => x.Name == comparisonInputModel.MyRank);

            IEnumerable<GameData> otherGames = games.Where(x => x.Id != comparisonInputModel.MyGameId);

            foreach (GameData game in otherGames)
            {
                string queueName = comparisonInputModel.Queues.FirstOrDefault(x => x.GameId == game.Id).Queue;
                QueueData league = game.Queues.FirstOrDefault(x => x.Name == queueName);
                RankGameComparison rankGameComparison = GetClosestRank(myRank, league);
                rankGameComparison.GameName = game.Name;
                rankGameComparison.GameId = game.Id;

                res.OtherGames.Add(rankGameComparison);
            }

            res.MyGame = new RankGameComparison()
            {
                GameName = myGame.Name,
                GameId = myGame.Id,
                Percentage = myRank.Percentage,
                Queue = comparisonInputModel.MyQueue,
                Rank = comparisonInputModel.MyRank
            };

            return res;
        }

        private RankGameComparison GetClosestRank(RankData myRank, QueueData compareGameLeagueData)
        {
            RankGameComparison res = new RankGameComparison();
            RankData compareRankData = compareGameLeagueData.Ranks.Where(x => x.Percentage > myRank.Percentage).MinBy(x => x.Percentage);
            res.Rank = compareRankData.Name;
            res.Percentage = compareRankData.Percentage;
            res.Queue = compareGameLeagueData.Name;

            return res;
        }
    }
}