using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Decorator.Normal;

namespace Practice.DesignPattern.Structural.Decorator
{
    [ApiController]
    [Route("api/structural/v1/non-decorator")]
    public class NonDecoratorController
    {
        private readonly IReportDataV2 _reportDataV2;

        public NonDecoratorController
        (
            IReportDataV2 reportDataV2
        )
        {
            _reportDataV2 = reportDataV2;
        }

        [HttpGet("try-get-data")]
        public async Task<PostData[]> GetData()
        {
            return await _reportDataV2.GetDataV2();
        }
    }
}
