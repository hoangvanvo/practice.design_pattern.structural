using Practice.DesignPattern.Structural.Decorator.Basic;

namespace Practice.DesignPattern.Structural.Facade.Contract
{
    public interface IShippingService
    {
        Task Schedule(Order order);
    }
}
