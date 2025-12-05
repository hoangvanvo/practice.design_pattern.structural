namespace Practice.DesignPattern.Structural.BigDemo.DTO.Responses
{
    public class PaymentResponse
    {
        public bool Success { get; set; }
        public string TransactionId { get; set; } = "";
        public string Message { get; set; } = "";

        public PaymentResponse() { }
        public PaymentResponse(bool success, string txId, string message = "")
        {
            Success = success;
            TransactionId = txId;
            Message = message;
        }
    }
}
