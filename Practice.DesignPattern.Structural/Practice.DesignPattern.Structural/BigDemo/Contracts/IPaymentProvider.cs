using Practice.DesignPattern.Structural.BigDemo.DTO.Requests;
using Practice.DesignPattern.Structural.BigDemo.DTO.Responses;

namespace Practice.DesignPattern.Structural.BigDemo.Contracts
{
    public interface IPaymentProvider
    {
        Task<PaymentResponse> PayAsync(PaymentRequest request);
    }
}
