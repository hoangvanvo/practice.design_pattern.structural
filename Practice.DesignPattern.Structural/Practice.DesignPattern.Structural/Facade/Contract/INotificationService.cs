namespace Practice.DesignPattern.Structural.Facade.Contract
{
    public interface INotificationService
    {
        Task Notify(Decorator.Basic.Order order);
    }
}
