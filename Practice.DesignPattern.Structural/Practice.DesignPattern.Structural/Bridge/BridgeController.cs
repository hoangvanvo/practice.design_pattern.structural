using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Bridge.Basic;
using Practice.DesignPattern.Structural.Bridge.DesignPattern;

namespace Practice.DesignPattern.Structural.Bridge
{
    [Route("api/structural/v1/bridge")]
    [ApiController]
    public class BridgeController : ControllerBase
    {
        private readonly PaymentFactory paymentFactory;

        public BridgeController(PaymentFactory paymentFactory)
        {
            this.paymentFactory = paymentFactory;
        }

        [HttpPost("basic")]
        public string BasicDemo([FromBody] BridgeRequest request)
        {
            Payment payment;
            switch (request.PaymentSource)
            {
                case 1: // Paypal
                    payment = request.PaymentType == 1 ? new PaypalOneTimePayment() as Payment : new PaypalSubscriptionPayment() as Payment;
                    break;
                case 2: // Stripe
                    payment = request.PaymentType == 1 ? new StripeOneTimePayment() as Payment : new StripeSubscriptionPayment() as Payment;
                    break;
                case 3: // Momo
                    payment = request.PaymentType == 1 ? new MomoOneTimePayment() as Payment : new MomoSubscriptionPayment() as Payment;
                    break;
                default:
                    return "[ERROR] Nguồn thanh toán không hợp lệ.";
            }
            return payment.Pay(request.Amount, request.CurrencyUnit);
        }

        [HttpPost("pattern")]
        public string PatternDemo([FromBody] BridgeRequest request)
        {
            var payment = paymentFactory.GetPayment(request.PaymentSource, request.PaymentType);
            return payment.Pay(request.PaymentType, request.Amount, request.CurrencyUnit);
        }
    }
}
