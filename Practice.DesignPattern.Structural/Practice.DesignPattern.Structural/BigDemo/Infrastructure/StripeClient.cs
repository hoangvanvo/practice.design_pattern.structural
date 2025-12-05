using Practice.DesignPattern.Structural.BigDemo.Data.Builder;

namespace Practice.DesignPattern.Structural.BigDemo.Infrastructure
{
    public class StripeClient
    {
        // Simulate a call to external stripe-like API
        public async Task<(bool Success, string TransactionId)> ChargeAsync(StripeChargeRequest req)
        {
            await Task.Delay(150); // simulate network
            return (true, "stripe_tx_" + Guid.NewGuid().ToString("N").Substring(0, 8));
        }
    }
}
