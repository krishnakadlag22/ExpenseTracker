//using Microsoft.AspNetCore.Mvc;

//namespace ExpenseTracker.Controllers
//{
//    public class EController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using ExpenseTracker.Data;

namespace ExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseDbContext _context;
        public ExpenseController(ExpenseDbContext context)
        {
            _context = context;
        }
        //private static List<Expense> expenses = new List<Expense>();
        //private static int nextId = 1;

        public IActionResult Index()
        {
            var expenses = _context.Expenses.ToList();
            ViewBag.Total = expenses.Sum(x => x.Amount);
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Expense exp)
        {
            if (ModelState.IsValid){
                _context.Expenses.Add(exp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var expense = _context.Expenses.FirstOrDefault(x => x.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }
        [HttpPost]
        public IActionResult Edit(Expense exp)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(exp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exp);
        }

        public IActionResult Delete(int id)
        {
            var item = _context.Expenses.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _context.Expenses.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}