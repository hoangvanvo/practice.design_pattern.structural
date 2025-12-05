using Practice.DesignPattern.Structural.Decorator.Basic;

namespace Practice.DesignPattern.Structural.Facade.Contract
{
    public interface IInventoryService
    {
        Task Reserve(Order order);
    }
}
