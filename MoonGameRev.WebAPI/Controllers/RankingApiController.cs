namespace MoonGameRev.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MoonGameRev.Services.Data.Interfaces;
    using MoonGameRev.Services.Data.Models.Ranking;


    [Route("api/ranking")]
    [ApiController]
    public class RankingApiController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public RankingApiController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(RankingServiceModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetRanking()
        {
            try
            {
                IEnumerable<RankingServiceModel> serviceModels = await this.reviewService.GetRankingAsync();
                return this.Ok(serviceModels);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}
