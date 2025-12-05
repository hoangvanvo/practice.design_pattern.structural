using Practice.DesignPattern.Structural.Decorator.Basic;
using Practice.DesignPattern.Structural.Facade.Contract;

namespace Practice.DesignPattern.Structural.Facade.Data
{
    public class ShippingService : IShippingService
    {
        public async Task Schedule(Order order) => Console.WriteLine($"Shipping scheduled for {order.ProductName}");
    }
}
