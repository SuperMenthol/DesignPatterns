namespace ProgramNamespace.Dto
{
    public class PaymentInfoDto
    {
        public Guid PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
    }
}