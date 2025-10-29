using Practice.DesignPattern.Structural.Bridge.Basic;

namespace Practice.DesignPattern.Structural.Bridge.DesignPattern
{
    // ===== IMPLEMENTOR =====
    public interface IPaymentGateway
    {
        string ProcessPayment(int PaymentType, decimal amount, string currency);
    }

    public class PaypalGateway : IPaymentGateway
    {
        public string ProcessPayment(int PaymentType, decimal amount, string currency)
        {
            switch (PaymentType)
            {
                case 1: // OneTime
                    return $"[PayPal] Thanh toán một lần {amount} {currency} qua PayPal API...";
                case 2: // Subscription
                    return $"[PayPal] Đăng ký gói {amount} {currency}/tháng qua PayPal API...";
                default:
                    return"[ERROR] Loại thanh toán không hợp lệ.";
            }
        }
    }

    public class StripeGateway : IPaymentGateway
    {
        public string ProcessPayment(int PaymentType, decimal amount, string currency)
        {
            switch (PaymentType)
            {
                case 1: // OneTime
                    return $"[Stripe] Thanh toán một lần {amount} {currency} qua Stripe API...";
                case 2: // Subscription
                    return $"[Stripe] Đăng ký gói {amount} {currency}/tháng qua Stripe API...";
                default:
                    return "[ERROR] Loại thanh toán không hợp lệ.";
            }
        }
    }

    public class MomoGateway : IPaymentGateway
    {
        public string ProcessPayment(int PaymentType, decimal amount, string currency)
        {
            switch (PaymentType)
            {
                case 1: // OneTime
                    return $"[Momo] Thanh toán một lần {amount} {currency} qua Momo API...";
                case 2: // Subscription
                    return $"[Momo] Đăng ký gói {amount} {currency}/tháng qua Momo API...";
                default:
                    return "[ERROR] Loại thanh toán không hợp lệ.";
            }
        }
    }

    // ===== ABSTRACTION =====
    public abstract class PatternPayment
    {
        protected readonly IPaymentGateway _gateway;

        protected PatternPayment(IPaymentGateway gateway)
        {
            _gateway = gateway;
        }

        public abstract string Pay(int PaymentType, decimal amount, string currency);
    }

    public class OneTimePayment : PatternPayment
    {
        public OneTimePayment(IPaymentGateway gateway) : base(gateway) { }

        public override string Pay(int PaymentType, decimal amount, string currency)
        {
            return _gateway.ProcessPayment(PaymentType, amount, currency);
        }
    }

    public class SubscriptionPayment : PatternPayment
    {
        public SubscriptionPayment(IPaymentGateway gateway) : base(gateway) { }

        public override string Pay(int PaymentType, decimal amount, string currency)
        {
            return _gateway.ProcessPayment(PaymentType,amount, currency);
        }
    }

    // ===== FACTORY =====
    public class PaymentFactory
    {
        public PatternPayment GetPayment(int PaymentSource, int PaymentType)
        {
            switch (PaymentSource)
            {
                case 1: // Paypal
                    return PaymentType == 1 ? new OneTimePayment(new PaypalGateway()) as PatternPayment : new SubscriptionPayment(new PaypalGateway()) as PatternPayment;
                case 2: // Stripe
                    return PaymentType == 1 ? new OneTimePayment(new StripeGateway()) as PatternPayment : new SubscriptionPayment(new StripeGateway()) as PatternPayment;
                case 3: // Momo
                    return PaymentType == 1 ? new OneTimePayment(new MomoGateway()) as PatternPayment : new SubscriptionPayment(new MomoGateway()) as PatternPayment;
                default:
                    throw new Exception("[ERROR] Nguồn thanh toán không hợp lệ.");
            }
        }
    }
}
