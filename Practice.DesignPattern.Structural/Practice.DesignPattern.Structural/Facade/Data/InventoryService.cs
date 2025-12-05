using Practice.DesignPattern.Structural.Decorator.Basic;
using Practice.DesignPattern.Structural.Facade.Contract;

namespace Practice.DesignPattern.Structural.Facade.Data
{
    public class InventoryService : IInventoryService
    {
        public async Task Reserve(Order order) => Console.WriteLine($"Inventory reserved for {order.ProductName}");
    }
}
