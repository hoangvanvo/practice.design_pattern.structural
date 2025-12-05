using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;
using Practice.DesignPattern.Structural.BigDemo.DTO.Responses;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Proxy
{
    public class RateLimitPaymentProxy : IPaymentProvider
    {
        private readonly IPaymentProvider _inner;
        private readonly Infrastructure.RateLimiter _limiter;

        public RateLimitPaymentProxy(IPaymentProvider inner, Infrastructure.RateLimiter limiter)
        {
            _inner = inner;
            _limiter = limiter;
        }

        public async Task<PaymentResponse> PayAsync(PaymentRequest request)
        {
            if (!_limiter.Allow())
                throw new Exception("Too many requests - rate limited");

            return await _inner.PayAsync(request);
        }
    }
}
