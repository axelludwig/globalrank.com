using GlobalRank.Core.Models;

namespace GlobalRank.Core.Interfaces.Repositories
{
    public interface IRankRepository
    {
        Dictionary<string, GameData> GetData();
    }
}
