using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Decorator;

namespace Practice.DesignPattern.Structural.Composite
{
    [Route("api/structural/v1/decorator")]
    [ApiController]
    public class DecoratorController : ControllerBase
    {
        private readonly IReportData _reportData;

        public DecoratorController(IReportData reportData)
        {
            _reportData = reportData;
        }

        [HttpGet("get-data")]
        public async Task<PostData[]> BasicDemo()
        {
            return await _reportData.GetData();
        }
    }
}
