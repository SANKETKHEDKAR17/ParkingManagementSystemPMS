using LoginAPI.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet]
    [Authorize(Policy = "UserPolicy")] // Both Admin and User can view payments
    public async Task<IActionResult> GetAllPayments()
    {
        var payments = await _paymentService.GetAllPayments();
        return Ok(payments);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "UserPolicy")] // Both Admin and User can view specific payment
    public async Task<IActionResult> GetPaymentById(int id)
    {
        var payment = await _paymentService.GetPaymentById(id);
        if (payment == null)
        {
            return NotFound();
        }
        return Ok(payment);
    }

    [HttpPost]
    [Authorize(Policy = "UserPolicy")] // Only Users can create payment
    public async Task<IActionResult> AddPayment([FromBody] Payment payment)
    {
        await _paymentService.AddPayment(payment);
        return CreatedAtAction(nameof(GetPaymentById), new { id = payment.PaymentID }, payment);
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "UserPolicy")] // Only Users can update payment
    public async Task<IActionResult> UpdatePayment(int id, [FromBody] Payment payment)
    {
        if (id != payment.PaymentID)
        {
            return BadRequest();
        }

        await _paymentService.UpdatePayment(payment);
        return NoContent();
    }

    [HttpDelete("removeReservationIfNoPayment/{reservationId}")]
    [Authorize(Policy = "UserPolicy")] // Both Admin and User can trigger reservation removal if payment not done
    public async Task<IActionResult> RemoveReservationIfNoPayment(int reservationId)
    {
        var paymentDone = await _paymentService.RemoveReservationIfPaymentNotDone(reservationId);
        if (!paymentDone)
        {
            return Ok("Reservation removed due to unpaid status.");
        }
        return Ok("Payment is done, reservation remains.");
    }
}
