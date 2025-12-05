using Practice.DesignPattern.Structural.BigDemo.Contracts;

namespace Practice.DesignPattern.Structural.BigDemo.Data.Resolver
{
    public class PaymentFactoryResolver
    {
        private readonly Dictionary<string, IPaymentProviderFactory> _map;

        public PaymentFactoryResolver(IEnumerable<IPaymentProviderFactory> factories)
        {
            _map = factories.ToDictionary(f => f.ProviderName.ToLower());
        }

        public IPaymentProviderFactory Resolve(string provider)
        {
            var key = provider.ToLower();
            if (!_map.ContainsKey(key))
                throw new Exception($"Unsupported provider: {provider}");
            return _map[key];
        }
    }
}
