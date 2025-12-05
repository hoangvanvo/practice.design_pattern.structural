using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Validator
{
    public class PaypalValidator : IPaymentValidator
    {
        public void Validate(PaymentRequest request)
        {
            if (string.IsNullOrEmpty(request.CustomerId)) throw new Exception("Paypal: missing customer id");
        }
    }
}
