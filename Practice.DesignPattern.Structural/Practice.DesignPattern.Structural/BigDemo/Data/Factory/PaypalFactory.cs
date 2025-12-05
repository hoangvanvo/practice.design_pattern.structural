using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.Data.Adapter;
using Practice.DesignPattern.Structural.BigDemo.Data.Mapper;
using Practice.DesignPattern.Structural.BigDemo.Data.Validator;
using Practice.DesignPattern.Structural.BigDemo.Infrastructure;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Factory
{
    public class PaypalFactory : IPaymentProviderFactory
    {
        private readonly PaypalClient _client;
        public string ProviderName => "paypal";

        public PaypalFactory(PaypalClient client)
        {
            _client = client;
        }

        public IPaymentProvider CreateProvider()
        {
            return new PaypalAdapter(_client);
        }

        public IPaymentValidator CreateValidator()
        {
            return new PaypalValidator();
        }

        public IPaymentMapper CreateMapper()
        {
            return new PaypalMapper();
        }
    }
}
