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
            RankComparison ret = Service.CompareRanks(comparisonInputModel);

            return Ok(ret);
        }
    }
}
