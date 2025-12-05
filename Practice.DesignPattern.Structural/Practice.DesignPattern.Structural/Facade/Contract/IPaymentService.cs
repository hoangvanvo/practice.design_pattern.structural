namespace Practice.DesignPattern.Structural.Facade.Contract
{
    public interface IPaymentService
    {
        Task Charge(Decorator.Basic.Order order);
    }
}
