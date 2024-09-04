namespace LoginAPI.Core
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int ReservationID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
