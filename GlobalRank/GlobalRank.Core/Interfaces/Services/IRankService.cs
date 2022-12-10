using GlobalRank.Core.Models.Data;

namespace GlobalRank.Core.Interfaces.Services
{
    public interface IRankService
    {
        ICollection<GameData> GetData();
    }
}
