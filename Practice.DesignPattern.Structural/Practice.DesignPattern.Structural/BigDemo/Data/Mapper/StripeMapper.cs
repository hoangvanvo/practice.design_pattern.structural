using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Mapper
{
    public class StripeMapper : IPaymentMapper
    {
        public PaymentRequest Map(PaymentRequest request)
        {
            // For example: force currency uppercase
            request.Currency = request.Currency?.ToUpper() ?? "USD";
            return request;
        }
    }
}
