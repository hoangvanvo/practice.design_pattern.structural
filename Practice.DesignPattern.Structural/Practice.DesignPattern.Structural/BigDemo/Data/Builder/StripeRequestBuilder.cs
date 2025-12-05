namespace Practice.DesignPattern.Structural.BigDemo.Data.Builder
{
    // Simple builder for provider-specific request object
    public class StripeRequestBuilder
    {
        private decimal _amount;
        private string _currency = "USD";
        private string _orderId = "";

        public StripeRequestBuilder SetAmount(decimal a) { _amount = a; return this; }
        public StripeRequestBuilder SetCurrency(string c) { _currency = c; return this; }
        public StripeRequestBuilder SetOrderId(string id) { _orderId = id; return this; }

        public StripeChargeRequest Build()
        {
            return new StripeChargeRequest { Amount = _amount, Currency = _currency, OrderId = _orderId };
        }
    }

    public class StripeChargeRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public string OrderId { get; set; } = "";
    }
}
