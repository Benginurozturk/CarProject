using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("test")]
        public IActionResult Test() // Test
        {
            var result = _paymentService.test();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(PaymentAddDto paymentAddDto) // Test
        {
            var result = _paymentService.Add(paymentAddDto);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
