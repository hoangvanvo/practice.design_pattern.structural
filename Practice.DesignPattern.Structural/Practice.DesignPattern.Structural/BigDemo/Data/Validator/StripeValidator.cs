using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Validator
{
    public class StripeValidator : IPaymentValidator
    {
        public void Validate(PaymentRequest request)
        {
            if (request.Amount <= 0) throw new Exception("Stripe: amount must be > 0");
            if (string.IsNullOrEmpty(request.OrderId)) throw new Exception("Stripe: missing order id");
        }
    }
}
