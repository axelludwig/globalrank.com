using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalRank.Core.Models.DisplayModels
{
    public class RankComparison
    {
        public RankGameComparison MyGame { get; set; }
        public ICollection<RankGameComparison> OtherGames { get; set; }
    }
}
