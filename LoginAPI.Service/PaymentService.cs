using LoginAPI.Core;
using LoginAPI.Repository;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IReservationRepository _reservationRepository;

    public PaymentService(IPaymentRepository paymentRepository, IReservationRepository reservationRepository)
    {
        _paymentRepository = paymentRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<IEnumerable<Payment>> GetAllPayments()
    {
        return await _paymentRepository.GetAllPayments();
    }

    public async Task<Payment> GetPaymentById(int id)
    {
        return await _paymentRepository.GetPaymentById(id);
    }

    public async Task AddPayment(Payment payment)
    {
        await _paymentRepository.AddPayment(payment);
    }

    public async Task UpdatePayment(Payment payment)
    {
        await _paymentRepository.UpdatePayment(payment);
    }

    public async Task<bool> IsPaymentDone(int reservationId)
    {
        var payment = await _paymentRepository.GetPaymentByReservationId(reservationId);
        return payment != null;
    }

    public async Task<bool> RemoveReservationIfPaymentNotDone(int reservationId)
    {
        var paymentDone = await IsPaymentDone(reservationId);
        if (!paymentDone)
        {
            await _reservationRepository.DeleteReservation(reservationId);
        }
        return paymentDone;
    }
}
