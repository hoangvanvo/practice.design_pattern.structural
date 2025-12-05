using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.Data.Adapter;
using Practice.DesignPattern.Structural.BigDemo.Data.Mapper;
using Practice.DesignPattern.Structural.BigDemo.Data.Validator;
using Practice.DesignPattern.Structural.BigDemo.Infrastructure;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Factory
{
    public class StripeFactory : IPaymentProviderFactory
    {
        private readonly StripeClient _client;
        public string ProviderName => "stripe";

        public StripeFactory(StripeClient client)
        {
            _client = client;
        }

        public IPaymentProvider CreateProvider()
        {
            return new StripeAdapter(_client);
        }

        public IPaymentValidator CreateValidator()
        {
            return new StripeValidator();
        }

        public IPaymentMapper CreateMapper()
        {
            return new StripeMapper();
        }
    }
}
