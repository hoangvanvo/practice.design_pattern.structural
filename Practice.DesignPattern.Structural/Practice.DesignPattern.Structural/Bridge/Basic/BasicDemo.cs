namespace Practice.DesignPattern.Structural.Bridge.Basic
{
    // ===========================
    // Base class
    // ===========================
    public abstract class Payment
    {
        public abstract string Pay(decimal amount, string currency);
    }

    // ===========================
    // PAYPAL IMPLEMENTATION
    // ===========================
    public class PaypalOneTimePayment : Payment
    {
        public override string Pay(decimal amount, string currency)
        {
            return $"[PayPal] Thanh toán {amount} {currency} thành công!";
        }
    }

    public class PaypalSubscriptionPayment : Payment
    {
        public override string Pay(decimal amount, string currency)
        {
            return $"[PayPal] Gói {amount} {currency}/tháng đã được kích hoạt!";
        }
    }

    // ===========================
    // STRIPE IMPLEMENTATION
    // ===========================
    public class StripeOneTimePayment : Payment
    {
        public override string Pay(decimal amount, string currency)
        {
            return $"[Stripe] Thanh toán {amount} {currency} thành công!";
        }
    }

    public class StripeSubscriptionPayment : Payment
    {
        public override string Pay(decimal amount, string currency)
        {
            return $"[Stripe] Đăng ký gói {amount} {currency}/tháng thành công!";
        }
    }

    // ===========================
    // MOMO IMPLEMENTATION
    // ===========================
    public class MomoOneTimePayment : Payment
    {
        public override string Pay(decimal amount, string currency)
        {
            return $"[Momo] Thanh toán {amount} {currency} thành công!";
        }
    }

    public class MomoSubscriptionPayment : Payment
    {
        public override string Pay(decimal amount, string currency)
        {
            return $"[Momo] Đăng ký gói {amount} {currency}/tháng thành công!";
        }
    }
}
