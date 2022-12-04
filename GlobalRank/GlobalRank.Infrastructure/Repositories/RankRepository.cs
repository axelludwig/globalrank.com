using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GlobalRank.Infrastructure.Repositories
{
    public class RankRepository
    {
        private readonly string _jsonPath;

        public RankRepository()
        {
            _jsonPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\data.json");
        }
    }
}
