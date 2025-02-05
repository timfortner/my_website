using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MY_WEBSITE.Models;
namespace MY_WEBSITE.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ExpenseDbContext _context;

    public HomeController(ILogger<HomeController> logger, ExpenseDbContext context)
    {
        _logger = logger;
        _context = context
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Expenses()
    {
        var expenses = _context.Expenses.ToList();
        var total = expenses.Sum(expense => expense.Amount);
        ViewBag.Total = total;
        return View();
    }

    public IActionResult CreateEditExpenses(int? id)
    {
        if (id.HasValue)
        {
            var expense = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }
        return View();
    }

    
    public IActionResult DeleteExpense(int id)
    {
        var expenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
        if (expenseInDb == null)
        {
            return NotFound();
        }
        _context.Expenses.Remove(expenseInDb);
        _context.SaveChanges();
        return View();
    }
    public IActionResult SubmitExpenseForm(Expense model)
    {
        if (model.Id == 0)
        {
            _context.Expenses.Add(model);        
        } else {
            _context.Expenses.Update(model);
        }
        
        _context.SaveChanges();
        return RedirectToAction("Expenses");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
