using Practice.DesignPattern.Structural.Decorator.Basic;
using Practice.DesignPattern.Structural.Facade.Contract;
using Practice.DesignPattern.Structural.Facade.Data;

namespace Practice.DesignPattern.Structural.Facade.Pattern
{
    public class FacadeRepository : IFacadeRepository
    {
        private readonly IInventoryService inventoryService;
        private readonly IPaymentService paymentService;
        private readonly IShippingService shippingService;
        private readonly INotificationService notificationService;

        public FacadeRepository
        (
            IInventoryService inventoryService,
            IPaymentService paymentService,
            IShippingService shippingService,
            INotificationService notificationService
        )
        {
            this.inventoryService = inventoryService;
            this.paymentService = paymentService;
            this.shippingService = shippingService;
            this.notificationService = notificationService;
        }

        public async Task PlaceOrder(Order order)
        {
            await inventoryService.Reserve(order);
            await paymentService.Charge(order);
            await shippingService.Schedule(order);
            await notificationService.Notify(order);
        }
    }
}
