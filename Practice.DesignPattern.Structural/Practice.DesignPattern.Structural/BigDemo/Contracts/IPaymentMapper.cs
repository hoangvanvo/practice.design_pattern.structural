using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;

namespace Practice.DesignPattern.Structural.BigDemo.Contracts
{
    public interface IPaymentMapper
    {
        PaymentRequest Map(PaymentRequest request);
    }
}
