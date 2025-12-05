using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.Data.Decorator;
using Practice.DesignPattern.Structural.BigDemo.Data.Proxy;
using Practice.DesignPattern.Structural.BigDemo.Data.Resolver;
using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;
using Practice.DesignPattern.Structural.BigDemo.DTO.Responses;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Facade
{
    public class PaymentFacade
    {
        private readonly PaymentFactoryResolver _resolver;
        private readonly IServiceProvider _sp;
        private readonly Infrastructure.RateLimiter _limiter;
        private readonly ILogger<PaymentFacade> _logger;

        public PaymentFacade(PaymentFactoryResolver resolver, IServiceProvider sp, Infrastructure.RateLimiter limiter, ILogger<PaymentFacade> logger)
        {
            _resolver = resolver;
            _sp = sp;
            _limiter = limiter;
            _logger = logger;
        }

        public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest req)
        {
            _logger.LogInformation("Processing payment for provider {Provider}", req.Provider);

            // Resolve factory (Abstract Factory)
            var factory = _resolver.Resolve(req.Provider);

            // Validate (factory provides validator)
            var validator = factory.CreateValidator();
            validator.Validate(req);

            // Map request if needed
            var mapper = factory.CreateMapper();
            var mapped = mapper.Map(req);

            // Create the core provider adapter
            IPaymentProvider provider = factory.CreateProvider();

            // Wrap with Proxy/Decorators
            provider = new RateLimitPaymentProxy(provider, _limiter);              // Proxy
            provider = new RetryPaymentDecorator(provider);                      // Decorator
            var logger = _sp.GetRequiredService<ILogger<LoggingPaymentDecorator>>();
            provider = new LoggingPaymentDecorator(provider, logger);           // Decorator

            // Execute
            var res = await provider.PayAsync(mapped);
            return res;
        }
    }
}
