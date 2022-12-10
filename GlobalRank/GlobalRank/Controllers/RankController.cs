using GlobalRank.Core.Interfaces.Services;
using GlobalRank.Core.Models.Data;
using GlobalRank.Core.Models.DisplayModels;
using GlobalRank.Core.Models.InputModel;
using Microsoft.AspNetCore.Mvc;

namespace GlobalRank.Controllers
{
    [ApiController]
    [Route("api/rank")]
    public class RankController : ControllerBase
    {
        private readonly IRankService Service;

        public RankController(IServiceProvider serviceProvider)
        {
            Service = serviceProvider.GetService(typeof(IRankService)) as IRankService;
        }


        [HttpGet]
        public ActionResult<ICollection<GameData>> Get()
        {
            return Ok(Service.GetData());
        }


        [HttpGet("compare")]
        public ActionResult<ICollection<RankComparison>> Compare([FromBody] ComparisonInputModel comparisonInputModel)
        {
            var ret = new RankComparison()
            {
                MyGame = new RankGameComparison()
                {
                    Name = "League of Legends",
                    Percentage = 10,
                    Rank = "Gold",
                    Queue = "SoloQ"
                },
                OtherGames = new List<RankGameComparison>()
                {
                    new RankGameComparison()
                    {
                        Name = "CSGO",
                        Rank = "Double AK 47",
                        Percentage = 11,
                         Queue = "Competitive"
                    },
                    new RankGameComparison()
                    {
                        Name = "Rocket League",
                        Rank = "gold",
                        Percentage = 12,
                        Queue = "Duo"
                    }
                }
            };

            return Ok(ret);
        }
    }
}
