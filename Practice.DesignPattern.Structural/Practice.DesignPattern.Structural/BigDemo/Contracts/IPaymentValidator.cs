using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;

namespace Practice.DesignPattern.Structural.BigDemo.Contracts
{
    public interface IPaymentValidator
    {
        void Validate(PaymentRequest request);
    }
}
