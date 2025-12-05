using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Decorator.Basic;
using Practice.DesignPattern.Structural.Facade.Contract;
using Practice.DesignPattern.Structural.Facade.Pattern;

namespace Practice.DesignPattern.Structural.Facade
{
    [Route("api/structural/v1/facade")]
    [ApiController]
    public class FacadeController : ControllerBase
    {
        private readonly IInventoryService inventoryService;
        private readonly IPaymentService paymentService;
        private readonly IShippingService shippingService;
        private readonly INotificationService notificationService;
        private readonly IFacadeRepository facadeRepository;

        public FacadeController
        (
            IInventoryService inventoryService
            , IPaymentService paymentService
            , IShippingService shippingService
            , INotificationService notificationService
            , IFacadeRepository facadeRepository
        )
        {
            this.inventoryService = inventoryService;
            this.paymentService = paymentService;
            this.shippingService = shippingService;
            this.notificationService = notificationService;
            this.facadeRepository = facadeRepository;
        }

        [HttpGet("basic")]
        public async Task<IActionResult> Basic()
        {
            var order = new Order { Id = 101, ProductName = "Laptop", Quantity = 1 };

            await inventoryService.Reserve(order);
            await paymentService.Charge(order);
            await shippingService.Schedule(order);
            await notificationService.Notify(order);
            return Ok();
        }

        [HttpGet("pattern")]
        public async Task<IActionResult> Pattern()
        {
            await facadeRepository.PlaceOrder(new Order { Id = 101, ProductName = "Laptop", Quantity = 1 });
            return Ok();
        }
    }
}
