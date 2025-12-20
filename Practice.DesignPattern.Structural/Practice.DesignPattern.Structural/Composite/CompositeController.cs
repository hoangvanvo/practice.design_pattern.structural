using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Composite.Pattern;

namespace Practice.DesignPattern.Structural.Composite
{
    [ApiController]
    [Route("api/structural/v1/composite")]
    public class CompositeController
    {
        [HttpPost("get-total-price")]
        public double GetTotalPrice([FromBody] Hop[] boxs) => boxs.Sum(s => s.GetTotalPrice());
    }
}
