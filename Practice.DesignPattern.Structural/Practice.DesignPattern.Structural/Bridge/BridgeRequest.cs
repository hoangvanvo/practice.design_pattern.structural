namespace Practice.DesignPattern.Structural.Bridge
{
    public class BridgeRequest
    {
        /// <summary>
        /// 1: Paypal, 2: Stripe, 3: Momo
        /// </summary>
        public int PaymentSource { get; set; }
        /// <summary>
        /// 1: OneTime, 2: Subscription
        /// </summary>
        public int PaymentType { get; set; }
        /// <summary>
        /// Số tiền
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Đơn vị tiền tệ
        /// </summary>
        public string CurrencyUnit { get; set; }
    }
}
