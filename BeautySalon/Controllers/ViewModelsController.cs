using Microsoft.AspNetCore.Mvc;
using BeautySalon.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Controllers;

public class ViewModelController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Surname,Name,FathersName,Phone")] Employee employee)
    {
        if (ModelState.IsValid)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }
}