//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ExpenseTracker.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ExpenseApiController : ControllerBase
//    {
//    }
//}
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using System.Collections.Generic;
using System;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseApiController : ControllerBase
    {
        // Sample in-memory data (just for demo)
        private static List<Expense> Expenses = new List<Expense>
        {
            new Expense { Id = 1, Title = "Groceries", Amount = 1000, Category = "Food", Date = DateTime.Today },
            new Expense { Id = 2, Title = "Rent", Amount = 5000, Category = "Housing", Date = DateTime.Today }
        };

        // GET: api/expenseapi
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Expenses);
        }

        // POST: api/expenseapi
        [HttpPost]
        public IActionResult Add(Expense expense)
        {
            expense.Id = Expenses.Count + 1;
            Expenses.Add(expense);
            return Ok(expense);
        }
    }
}