using Microsoft.AspNetCore.Mvc;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService<double> _calculator;

        public CalculatorController(ICalculatorService<double> calculator)
        {
            _calculator = calculator;
        }

        [HttpGet("add")]
        public ActionResult<double> Add(double a, double b) => _calculator.Add(a, b);

        [HttpGet("subtract")]
        public ActionResult<double> Subtract(double a, double b) => _calculator.Subtract(a, b);

        [HttpGet("multiply")]
        public ActionResult<double> Multiply(double a, double b) => _calculator.Multiply(a, b);

        [HttpGet("divide")]
        public ActionResult<double> Divide(double a, double b)
        {
            try
            {
                return _calculator.Divide(a, b);
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
