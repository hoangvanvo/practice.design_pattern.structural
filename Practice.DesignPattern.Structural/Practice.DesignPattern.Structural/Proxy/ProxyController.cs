using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Proxy.Contracts;

namespace Practice.DesignPattern.Structural.Proxy
{
    [Route("api/structural/v1/proxy")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IOrderServiceProxy orderServiceProxy;

        public ProxyController
        (
            IOrderService service,
            IOrderServiceProxy orderServiceProxy
        )
        {
            _service = service;
            this.orderServiceProxy = orderServiceProxy;
        }

        [HttpPost("basic")]
        public async Task<IActionResult> PlaceOrder(OrderRequest req)
        {
            return Ok(await _service.PlaceOrderAsync(req));
        }

        [HttpPost("pattern")]
        public async Task<IActionResult> Place(OrderRequest req)
        {
            return Ok(await orderServiceProxy.PlaceOrderAsync(req));
        }
    }
}
