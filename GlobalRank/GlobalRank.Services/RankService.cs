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

            GameData myGame = GetGameDataById(comparisonInputModel.MyGameId, games);

            QueueData myQueue = GetQueueDataByName(comparisonInputModel.MyQueue, myGame);

            RankData myRank = GetRankDataByName(comparisonInputModel.MyRank, myQueue);

            IEnumerable<GameData> otherGames = games.Where(x => x.Id != comparisonInputModel.MyGameId);

            foreach (GameData otherGame in otherGames)
            {
                ComparisonGameInputModel compareGame = GetComparisonGameById(otherGame.Id, comparisonInputModel);

                QueueData queue = GetQueueDataByName(compareGame.Queue, otherGame);
                RankGameComparison rankGameComparison = GetClosestRank(myRank, queue);
                rankGameComparison.GameName = otherGame.Name;
                rankGameComparison.GameId = otherGame.Id;

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

        private GameData GetGameDataById(string gameId, IEnumerable<GameData> gamesData)
        {
            GameData res = gamesData.FirstOrDefault(x => x.Id == gameId);
            if (res == null)
            {
                throw new ArgumentException($"Game id {gameId} not existing");
            }

            return res;
        }

        private QueueData GetQueueDataByName(string queueName, GameData gameData)
        {
            QueueData res = gameData.Queues.FirstOrDefault(x => x.Name == queueName);
            if (res == null)
            {
                throw new ArgumentException($"Queue {queueName} not existing");
            }

            return res;
        }

        private RankData GetRankDataByName(string rankName, QueueData queueData)
        {
            RankData res = queueData.Ranks.FirstOrDefault(x => x.Name == rankName);
            if (res == null)
            {
                throw new ArgumentException($"Rank {rankName} not existing");
            }

            return res;
        }

        private ComparisonGameInputModel GetComparisonGameById(string gameId, ComparisonInputModel comparisonInputModel)
        {
            ComparisonGameInputModel res = comparisonInputModel.Queues.FirstOrDefault(x => x.GameId == gameId);
            if (res == null)
            {
                throw new ArgumentException($"Game {gameId} not existing");
            }

            return res;
        }
    }
}