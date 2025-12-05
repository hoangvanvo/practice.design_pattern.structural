using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;
using Practice.DesignPattern.Structural.BigDemo.DTO.Responses;
using Practice.DesignPattern.Structural.BigDemo.Infrastructure;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Adapter
{
    public class PaypalAdapter : IPaymentProvider
    {
        private readonly PaypalClient _client;

        public PaypalAdapter(PaypalClient client)
        {
            _client = client;
        }

        public async Task<PaymentResponse> PayAsync(PaymentRequest request)
        {
            var result = await _client.MakePaymentAsync(request.Amount, request.OrderId);
            return new PaymentResponse(result.IsSuccess, result.PaymentId);
        }
    }
}
