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

namespace ExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private static List<Expense> expenses = new List<Expense>();
        private static int nextId = 1;

        public IActionResult Index()
        {
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
            exp.Id = nextId++;
            expenses.Add(exp);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = expenses.FirstOrDefault(x => x.Id == id);
            if (item != null) expenses.Remove(item);
            return RedirectToAction("Index");
        }
    }
}