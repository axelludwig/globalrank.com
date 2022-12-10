using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalRank.Core.Models.Data
{
    public class LeagueData
    {
        public string Name { get; set; }
        public ICollection<RankData> Ranks { get; set; }
    }
}
