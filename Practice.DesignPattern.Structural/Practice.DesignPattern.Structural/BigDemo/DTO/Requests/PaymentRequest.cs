namespace Practice.DesignPattern.Structural.BigDemo.DTO.Requests
{
    public class PaymentRequest
    {
        public string Provider { get; set; } = "";
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public string OrderId { get; set; } = "";
        public string CustomerId { get; set; } = "";
    }
}
