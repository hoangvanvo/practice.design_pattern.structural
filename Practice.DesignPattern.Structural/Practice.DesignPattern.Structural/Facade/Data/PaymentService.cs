using Practice.DesignPattern.Structural.Decorator.Basic;
using Practice.DesignPattern.Structural.Facade.Contract;

namespace Practice.DesignPattern.Structural.Facade.Data
{
    public class PaymentService : IPaymentService
    {
        public async Task Charge(Order order) => Console.WriteLine($"Payment charged for {order.ProductName}");
    }
}
