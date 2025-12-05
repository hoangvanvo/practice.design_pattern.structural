using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;
using Practice.DesignPattern.Structural.BigDemo.DTO.Responses;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Decorator
{
    public class LoggingPaymentDecorator : IPaymentProvider
    {
        private readonly IPaymentProvider _inner;
        private readonly ILogger<LoggingPaymentDecorator> _logger;

        public LoggingPaymentDecorator(IPaymentProvider inner, ILogger<LoggingPaymentDecorator> logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public async Task<PaymentResponse> PayAsync(PaymentRequest request)
        {
            _logger.LogInformation("Start provider {Provider}", _inner.GetType().Name);
            var res = await _inner.PayAsync(request);
            _logger.LogInformation("Provider {Provider} finished: success={Success}", _inner.GetType().Name, res.Success);
            return res;
        }
    }
}
