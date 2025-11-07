namespace Practice.DesignPattern.Structural.Decorator.Basic
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }

    public interface IOrderService
    {
        void PlaceOrder(Order order);
    }

    public class OrderService : IOrderService
    {
        public void PlaceOrder(Order order)
        {
            Console.WriteLine($"Placing order {order.Id}");
            // Simulate business logic
            Thread.Sleep(100);
        }
    }

    public class OrderServiceWithLoggingAndRetry : IOrderService
    {
        private readonly IOrderService _inner;
        public OrderServiceWithLoggingAndRetry(IOrderService inner)
        {
            _inner = inner;
        }

        public void PlaceOrder(Order order)
        {
            Console.WriteLine("Start placing order...");
            int retryCount = 0;
            while (true)
            {
                try
                {
                    _inner.PlaceOrder(order);
                    Console.WriteLine("Order placed successfully.");
                    break;
                }
                catch (Exception ex)
                {
                    retryCount++;
                    if (retryCount > 3)
                        throw;
                    Console.WriteLine($"Retry {retryCount} due to {ex.Message}");
                }
            }
        }
    }

}
