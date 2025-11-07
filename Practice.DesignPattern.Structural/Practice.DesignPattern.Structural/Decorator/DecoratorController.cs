using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Decorator.Basic;

namespace Practice.DesignPattern.Structural.Composite
{
    [Route("api/structural/v1/decorator")]
    [ApiController]
    public class DecoratorController : ControllerBase
    {
        private readonly Decorator.DesignPattern.IOrderService patternOrderService;

        public DecoratorController
        (
            Decorator.DesignPattern.IOrderService patternOrderService
        )
        {
            this.patternOrderService = patternOrderService;
        }

        [HttpGet("basic")]
        public void BasicDemo()
        {
            // Composition root (Program.cs / Startup.cs)
            Decorator.Basic.IOrderService service = new Decorator.Basic.OrderService();
            // Execute
            service.PlaceOrder(new Order { Id = 123 });
        }

        [HttpPost("pattern")]
        public IActionResult PatternDemo([FromBody] Order order)
        {
            try
            {
                patternOrderService.PlaceOrder(order);
                return Ok(new { message = $"Order {order.Id} processed successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
