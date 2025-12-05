namespace Practice.DesignPattern.Structural.BigDemo.Contracts
{
    public interface IPaymentProviderFactory
    {
        string ProviderName { get; } // "stripe", "paypal", ...
        IPaymentProvider CreateProvider();
        IPaymentValidator CreateValidator();
        IPaymentMapper CreateMapper();
    }
}
