using GlobalRank.Core.Models;

namespace GlobalRank.Core.Interfaces.Repositories
{
    public interface IRankRepository
    {
        ICollection<GameData> GetData();
    }
}
