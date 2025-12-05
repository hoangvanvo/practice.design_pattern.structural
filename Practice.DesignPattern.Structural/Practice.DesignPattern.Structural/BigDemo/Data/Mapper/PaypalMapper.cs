using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Mapper
{
    public class PaypalMapper : IPaymentMapper
    {
        public PaymentRequest Map(PaymentRequest request)
        {
            // Example mapping: round amount
            request.Amount = Math.Round(request.Amount, 2);
            return request;
        }
    }
}
