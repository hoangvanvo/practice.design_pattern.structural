namespace Practice.DesignPattern.Structural.Proxy.Contracts
{
    public class OrderRequest
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public interface IOrderService
    {
        Task<string> PlaceOrderAsync(OrderRequest request);
    }

    public class OrderService : IOrderService
    {
        public async Task<string> PlaceOrderAsync(OrderRequest request)
        {
            // Gọi DB
            // Gọi Payment API
            // Gọi Inventory API
            await Task.Delay(200); // giả lập xử lý nặng
            return $"Order {request.OrderId} Placed";
        }
    }



    public interface IOrderServiceProxy
    {
        Task<string> PlaceOrderAsync(OrderRequest request);
    }

    public class OrderServiceProxy : IOrderServiceProxy
    {
        public async Task<string> PlaceOrderAsync(OrderRequest request)
        {
            await Task.Delay(200); // simulate heavy logic
            return $"Order {request.OrderId} Placed";
        }
    }

    public class LoggingOrderServiceProxy : IOrderServiceProxy
    {
        private readonly IOrderServiceProxy _inner;
        private readonly ILogger<LoggingOrderServiceProxy> _logger;

        public LoggingOrderServiceProxy(
            IOrderServiceProxy inner,
            ILogger<LoggingOrderServiceProxy> logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public async Task<string> PlaceOrderAsync(OrderRequest request)
        {
            _logger.LogInformation("[LOG] Start order {Id}", request.OrderId);
            var result = await _inner.PlaceOrderAsync(request);
            _logger.LogInformation("[LOG] Finished order {Id}", request.OrderId);
            return result;
        }
    }

    public class RetryOrderServiceProxy : IOrderServiceProxy
    {
        private readonly IOrderServiceProxy _inner;

        public RetryOrderServiceProxy(IOrderServiceProxy inner)
        {
            _inner = inner;
        }

        public async Task<string> PlaceOrderAsync(OrderRequest request)
        {
            int retry = 0;
            while (true)
            {
                try
                {
                    return await _inner.PlaceOrderAsync(request);
                }
                catch (Exception ex)
                {
                    retry++;
                    if (retry > 3) throw;
                    Console.WriteLine($"Retry #{retry} due to {ex.Message}");
                }
            }
        }
    }

    public class AuthorizationOrderServiceProxy : IOrderServiceProxy
    {
        private readonly IOrderServiceProxy _inner;
        private readonly IHttpContextAccessor _context;

        public AuthorizationOrderServiceProxy(
            IOrderServiceProxy inner,
            IHttpContextAccessor context)
        {
            _inner = inner;
            _context = context;
        }

        public async Task<string> PlaceOrderAsync(OrderRequest request)
        {
            var user = _context.HttpContext?.User;

            if (!user?.IsInRole("OrderCreator") ?? true)
                throw new UnauthorizedAccessException("You cannot place orders.");

            return await _inner.PlaceOrderAsync(request);
        }
    }
}
