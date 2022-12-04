using GlobalRank.Core.Interfaces.Repositories;
using GlobalRank.Core.Models;
using System.Reflection;
using System.Text.Json;

namespace GlobalRank.Infrastructure.Repositories
{
    public class RankRepository : IRankRepository
    {
        private readonly string _jsonPath;

        public RankRepository()
        {
            _jsonPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\data.json");

        }

        public ICollection<GameData> GetData()
        {
            string json = File.ReadAllText(_jsonPath);
            ICollection<GameData> data = JsonSerializer.Deserialize<ICollection<GameData>>(json);

            return data;
        }
    }
}
