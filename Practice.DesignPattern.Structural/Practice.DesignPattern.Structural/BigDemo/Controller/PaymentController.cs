using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.BigDemo.Data.Facade;
using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;

namespace Practice.DesignPattern.Structural.BigDemo.Controller
{
    [Route("api/structural/v1/demo-payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentFacade _facade;

        public PaymentController(PaymentFacade facade)
        {
            _facade = facade;
        }

        [HttpPost]
        public async Task<IActionResult> Pay([FromBody] PaymentRequest request)
        {
            try
            {
                var response = await _facade.ProcessPaymentAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
