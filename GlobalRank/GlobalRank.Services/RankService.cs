using GlobalRank.Core.Interfaces.Repositories;
using GlobalRank.Core.Interfaces.Services;
using GlobalRank.Core.Models;

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
    }
}