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
        return View();
    }

    public IActionResult CreateEditExpenses()
    {
        return View();
    }
    public IActionResult SubmitExpenseForm(Expense model)
    {
        _context.Expenses.Add(model);
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
