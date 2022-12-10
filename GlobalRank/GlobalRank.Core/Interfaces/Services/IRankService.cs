using GlobalRank.Core.Models.Data;
using GlobalRank.Core.Models.DisplayModels;
using GlobalRank.Core.Models.InputModel;

namespace GlobalRank.Core.Interfaces.Services
{
    public interface IRankService
    {
        /// <summary>
        /// Gets current game ranks data
        /// </summary>
        /// <returns></returns>
        ICollection<GameData> GetData();

        /// <summary>
        /// Compares rank of in user game with other games
        /// </summary>
        /// <param name="comparisonInputModel"></param>
        /// <returns></returns>
        RankComparison CompareRanks(ComparisonInputModel comparisonInputModel);
    }
}
