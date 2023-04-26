using Microsoft.AspNetCore.Mvc;
using BeautySalon.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using ModelError = Microsoft.AspNetCore.Mvc.ModelBinding.ModelError;
using ModelState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;

namespace BeautySalon.Controllers;

public class ViewModelsController : Controller
{
    private readonly BeautysalonContext _context;

    
    public ViewModelsController(BeautysalonContext context)
    {
        _context = context;
    }
    
    public IActionResult Create()
    {
        ViewData["PosId"] = new SelectList(_context.Positions, "Id", "Id");
        ViewData["EmpId"] = new SelectList(_context.Employees, "Id", "Id");
        return View();
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    [Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Microsoft.AspNetCore.Mvc.Bind("Employee")] ViewModel model)
    {
        foreach (ModelState modelState in ViewData.ModelState.Values)
        {
            foreach (ModelError error in modelState.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }
        if (ModelState.IsValid)
        { 
            _context.Add(model.Employee);
            await _context.SaveChangesAsync();
            
            model.EmployeesOnPosition.Posid = model.EmployeesOnPosition.Pos.Id;
            model.EmployeesOnPosition.Empid = model.Employee.Id;
            _context.Add(model.EmployeesOnPosition);
            await _context.SaveChangesAsync();
            return Redirect("/Employees");
        }
        return View();
    }
}