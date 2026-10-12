using Microsoft.AspNetCore.Mvc;
using QuadraticEquation.Data;
using QuadraticEquation.Models;

namespace QuadraticEquation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("solve")]
        public async Task<IActionResult> Solve([FromBody] SolveRequest request)
        {
            if (request.A == 0)
            {
                return BadRequest("Hệ số 'a' phải khác 0 đối với phương trình bậc 2.");
            }

            double a = request.A;
            double b = request.B;
            double c = request.C;

            double delta = b * b - 4 * a * c;
            string resultText;

            if (delta < 0)
            {
                resultText = "Phương trình vô nghiệm.";
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                resultText = $"Phương trình có nghiệm kép: x = {x}";
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                resultText = $"Phương trình có 2 nghiệm phân biệt: x1 = {x1}, x2 = {x2}";
            }

            var history = new EquationHistory
            {
                A = a,
                B = b,
                C = c,
                Delta = delta,
                Result = resultText,
                CreatedAt = DateTime.Now
            };

            _context.EquationHistories.Add(history);
            await _context.SaveChangesAsync();

            return Ok(history);
        }

        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            var list = _context.EquationHistories
                .OrderByDescending(h => h.CreatedAt)
                .ToList();

            return Ok(list);
        }
    }
}