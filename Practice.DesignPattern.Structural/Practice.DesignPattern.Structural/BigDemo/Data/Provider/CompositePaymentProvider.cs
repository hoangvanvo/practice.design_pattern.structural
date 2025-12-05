using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;
using Practice.DesignPattern.Structural.BigDemo.DTO.Responses;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Provider
{
    // Example: split payment across several providers
    public class CompositePaymentProvider : IPaymentProvider
    {
        private readonly IEnumerable<(IPaymentProvider Provider, decimal Ratio)> _parts;

        public CompositePaymentProvider(IEnumerable<(IPaymentProvider, decimal)> parts)
        {
            _parts = parts;
        }

        public async Task<PaymentResponse> PayAsync(PaymentRequest request)
        {
            foreach (var (provider, ratio) in _parts)
            {
                var partial = new PaymentRequest
                {
                    Provider = request.Provider,
                    Amount = Math.Round(request.Amount * ratio, 2),
                    Currency = request.Currency,
                    OrderId = request.OrderId,
                    CustomerId = request.CustomerId
                };

                await provider.PayAsync(partial);
            }

            return new PaymentResponse(true, "COMPOSITE_SUCCESS");
        }
    }
}
