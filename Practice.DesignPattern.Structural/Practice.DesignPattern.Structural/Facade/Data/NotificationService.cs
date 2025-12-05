using Practice.DesignPattern.Structural.Decorator.Basic;
using Practice.DesignPattern.Structural.Facade.Contract;

namespace Practice.DesignPattern.Structural.Facade.Data
{
    public class NotificationService : INotificationService
    {
        public async Task Notify(Order order) => Console.WriteLine($"Notification sent for order {order.Id}");
    }
}
