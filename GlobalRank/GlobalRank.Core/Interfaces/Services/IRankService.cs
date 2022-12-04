using GlobalRank.Core.Models;

namespace GlobalRank.Core.Interfaces.Services
{
    public interface IRankService
    {
        ICollection<GameData> GetData();
    }
}
