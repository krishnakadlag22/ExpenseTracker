using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using ExpenseTracker.Data;
using System.Linq;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseApiController : ControllerBase
    {
        private readonly ExpenseDbContext _context;

        public ExpenseApiController(ExpenseDbContext context)
        {
            _context = context;
        }

        // GET: api/expenseapi
        [HttpGet]
        public IActionResult GetAll()
        {
            var expenses = _context.Expenses.ToList();
            return Ok(expenses);
        }

        // GET: api/expenseapi/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var expense = _context.Expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
                return NotFound();

            return Ok(expense);
        }

        // POST: api/expenseapi
        [HttpPost]
        public IActionResult Add([FromBody]Expense expense)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Expenses.Add(expense);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = expense.Id }, expense);
        }

        // DELETE: api/expenseapi/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Expenses.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            _context.Expenses.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
