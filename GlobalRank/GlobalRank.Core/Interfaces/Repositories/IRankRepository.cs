using GlobalRank.Core.Models.Data;

namespace GlobalRank.Core.Interfaces.Repositories
{
    public interface IRankRepository
    {
        ICollection<GameData> GetData();
    }
}
