using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;
using Practice.DesignPattern.Structural.BigDemo.DTO.Responses;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Decorator
{
    public class RetryPaymentDecorator : IPaymentProvider
    {
        private readonly IPaymentProvider _inner;
        private readonly int _maxRetries = 3;

        public RetryPaymentDecorator(IPaymentProvider inner)
        {
            _inner = inner;
        }

        public async Task<PaymentResponse> PayAsync(PaymentRequest request)
        {
            int attempt = 0;
            while (true)
            {
                try
                {
                    return await _inner.PayAsync(request);
                }
                catch (Exception)
                {
                    attempt++;
                    if (attempt >= _maxRetries) throw;
                    // simple backoff
                    await Task.Delay(100 * attempt);
                }
            }
        }
    }
}
