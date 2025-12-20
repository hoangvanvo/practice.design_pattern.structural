using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Composite.Normal;

namespace Practice.DesignPattern.Structural.Composite
{
    [ApiController]
    [Route("api/structural/v1/non-composite")]
    public class NonCompositeController
    {

        [HttpPost("get-total-price")]
        public double GetTotalPrice([FromBody] Hop[] boxs) 
        {
            double total = 0.0;
            var priceRepository = new PriceRepository();
            priceRepository.TotalPrice(boxs, total);
            return total;
        }
    }
}
