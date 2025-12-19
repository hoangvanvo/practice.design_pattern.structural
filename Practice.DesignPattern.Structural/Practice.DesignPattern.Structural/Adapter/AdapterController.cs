using Microsoft.AspNetCore.Mvc;

namespace Practice.DesignPattern.Structural.Adapter
{
    [ApiController]
    [Route("api/structural/v1/adapter")]
    public class AdapterController : ControllerBase
    {
        private readonly IReportDataOverview _reportDataOverview;

        public AdapterController(IReportDataOverview reportDataOverview)
        {
            _reportDataOverview = reportDataOverview;
        }

        [HttpGet("get-data-overview")]
        public async Task<FeedData[]> GetDataOverview([FromServices] IReportDataOverview reportDataOverview)
        {
            return await _reportDataOverview.GetDataOverview();
        }
    }
}
