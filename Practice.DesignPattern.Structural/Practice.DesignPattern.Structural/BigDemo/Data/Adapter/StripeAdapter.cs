using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.Data.Builder;
using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;
using Practice.DesignPattern.Structural.BigDemo.DTO.Responses;
using Practice.DesignPattern.Structural.BigDemo.Infrastructure;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Adapter
{
    public class StripeAdapter : IPaymentProvider
    {
        private readonly StripeClient _client;

        public StripeAdapter(StripeClient client)
        {
            _client = client;
        }

        public async Task<PaymentResponse> PayAsync(PaymentRequest request)
        {
            // Use builder to create provider-specific request
            var stripeReq = new StripeRequestBuilder()
                .SetAmount(request.Amount)
                .SetCurrency(request.Currency)
                .SetOrderId(request.OrderId)
                .Build();

            var result = await _client.ChargeAsync(stripeReq);
            return new PaymentResponse(result.Success, result.TransactionId);
        }
    }
}
