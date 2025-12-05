using Practice.DesignPattern.Structural.Decorator.Basic;

namespace Practice.DesignPattern.Structural.Facade.Pattern
{
    public interface IFacadeRepository
    {
        Task PlaceOrder(Order order);
    }
}
