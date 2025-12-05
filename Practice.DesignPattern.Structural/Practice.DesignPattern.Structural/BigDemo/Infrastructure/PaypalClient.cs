namespace Practice.DesignPattern.Structural.BigDemo.Infrastructure
{
    public class PaypalClient
    {
        public async Task<(bool IsSuccess, string PaymentId)> MakePaymentAsync(decimal amount, string orderId)
        {
            await Task.Delay(120);
            return (true, "paypal_tx_" + Guid.NewGuid().ToString("N").Substring(0, 8));
        }
    }
}
