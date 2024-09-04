using LoginAPI.Core;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> GetAllPayments();
    Task<Payment> GetPaymentById(int id);
    Task AddPayment(Payment payment);
    Task UpdatePayment(Payment payment);
    Task<bool> IsPaymentDone(int reservationId);
    Task<bool> RemoveReservationIfPaymentNotDone(int reservationId);
}
