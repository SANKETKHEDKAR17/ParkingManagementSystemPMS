using LoginAPI.Core;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> GetAllPayments();
    Task<Payment> GetPaymentById(int id);
    Task<Payment> GetPaymentByReservationId(int reservationId);
    Task AddPayment(Payment payment);
    Task UpdatePayment(Payment payment);
}
