using Microsoft.Extensions.Caching.Memory;
using Polly;
using Polly.Retry;
using Practice.DesignPattern.Structural.Decorator.Basic;

namespace Practice.DesignPattern.Structural.Decorator.DesignPattern
{
    public interface IOrderService
    {
        void PlaceOrder(Order order);
    }

    public class OrderService : IOrderService
    {
        private static int _attempt = 0;

        public void PlaceOrder(Order order)
        {
            _attempt++;

            // Simulate random transient error
            if (_attempt % 3 != 0)
            {
                throw new Exception("NetworkError: simulated transient failure");
            }

            Console.WriteLine($"✅ Order {order.Id} placed successfully for {order.ProductName}");
        }
    }

    //Decorator
    public abstract class OrderServiceDecorator : IOrderService
    {
        protected readonly IOrderService _inner;

        protected OrderServiceDecorator(IOrderService inner)
        {
            _inner = inner;
        }

        public virtual void PlaceOrder(Order order)
        {
            _inner.PlaceOrder(order);
        }
    }

    //Logging Decorator
    public class LoggingOrderServiceDecorator : OrderServiceDecorator
    {
        private readonly ILogger<LoggingOrderServiceDecorator> _logger;

        public LoggingOrderServiceDecorator(IOrderService inner, ILogger<LoggingOrderServiceDecorator> logger)
            : base(inner)
        {
            _logger = logger;
        }

        public override void PlaceOrder(Order order)
        {
            _logger.LogInformation("➡️  Start placing order {OrderId}", order.Id);
            try
            {
                base.PlaceOrder(order);
                _logger.LogInformation("✅ Successfully placed order {OrderId}", order.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error placing order {OrderId}", order.Id);
                throw;
            }
        }
    }

    //Retry Decorator
    public class RetryOrderServiceDecorator : OrderServiceDecorator
    {
        private readonly AsyncRetryPolicy _retryPolicy;

        public RetryOrderServiceDecorator(IOrderService inner) : base(inner)
        {
            _retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromMilliseconds(300),
                    (exception, timeSpan, retryCount, context) =>
                    {
                        Console.WriteLine($"⚠️  Retry #{retryCount} due to: {exception.Message}");
                    });
        }

        public override void PlaceOrder(Order order)
        {
            _retryPolicy.ExecuteAsync(async () =>
            {
                _inner.PlaceOrder(order);
                await Task.CompletedTask;
            }).GetAwaiter().GetResult();
        }
    }

    //Caching Decorator
    public class CachingOrderServiceDecorator : OrderServiceDecorator
    {
        private readonly IMemoryCache _cache;

        public CachingOrderServiceDecorator(IOrderService inner) : base(inner)
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public override void PlaceOrder(Order order)
        {
            var cacheKey = $"order-{order.Id}";
            if (_cache.TryGetValue(cacheKey, out bool processed) && processed)
            {
                Console.WriteLine($"🧠 Cache hit for order {order.Id}, skipping processing...");
                return;
            }

            base.PlaceOrder(order);
            _cache.Set(cacheKey, true, TimeSpan.FromMinutes(10));
        }
    }
}
