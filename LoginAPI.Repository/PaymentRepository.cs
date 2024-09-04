using Dapper;
using LoginAPI.Core;
using Microsoft.Data.SqlClient;

public class PaymentRepository : IPaymentRepository
{
    private readonly string _connectionString;

    public PaymentRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<Payment>> GetAllPayments()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            return await connection.QueryAsync<Payment>("SELECT * FROM Payment");
        }
    }

    public async Task<Payment> GetPaymentById(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            return await connection.QuerySingleOrDefaultAsync<Payment>("SELECT * FROM Payment WHERE PaymentID = @Id", new { Id = id });
        }
    }

    public async Task<Payment> GetPaymentByReservationId(int reservationId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            return await connection.QuerySingleOrDefaultAsync<Payment>("SELECT * FROM Payment WHERE ReservationID = @ReservationID", new { ReservationID = reservationId });
        }
    }

    public async Task AddPayment(Payment payment)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = "INSERT INTO Payment (ReservationID, Amount, PaymentDate) VALUES (@ReservationID, @Amount, @PaymentDate)";
            await connection.ExecuteAsync(query, payment);
        }
    }

    public async Task UpdatePayment(Payment payment)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = "UPDATE Payment SET ReservationID = @ReservationID, Amount = @Amount, PaymentDate = @PaymentDate WHERE PaymentID = @PaymentID";
            await connection.ExecuteAsync(query, payment);
        }
    }
}
