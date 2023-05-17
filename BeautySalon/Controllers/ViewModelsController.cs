using Microsoft.AspNetCore.Mvc;
using BeautySalon.Data.Models;
using Microsoft.EntityFrameworkCore;
// using System.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        ViewData["Pos"] = new SelectList(_context.Positions, "Id", "Name");
        return View();
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    [Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Employee", "EmployeesOnPosition")] ViewModel model)
    {
        _context.Add(model.Employee);
        await _context.SaveChangesAsync();
        model.EmployeesOnPosition.Empid = model.Employee.Id;
        _context.Add(model.EmployeesOnPosition);
        await _context.SaveChangesAsync();
        return Redirect("/Employees");
    }

    public async Task<IActionResult> AddPos(long id)
    {
        var employees = _context.Employees.Include("EmployeesOnPositions.Pos").Where(emp=>emp.Id==id);
        var emp = await employees.FirstAsync();

        var takenPos = _context.EmployeesOnPositions.Where(emponpos=>emponpos.Empid==id);
        IEnumerable<Position> poses = _context.Positions;
        foreach (var pos in takenPos)
        {
            if (emp.EmployeesOnPositions.Contains(pos))
            {
                poses = poses.Where(p => p.Id != pos.Posid);
            }
        }
        ViewData["Pos"] = new SelectList(poses, "Id", "Name"); // await _context.Positions.Where(p=> _context.EmployeesOnPositions.FindAsync(p.Id) = false)
        var viewmodel = new ViewModel
        {
            Employee = emp
        };
        return View(viewmodel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddPos(long id, [Bind("Employee, EmployeesOnPosition")] ViewModel model)
    {
        model.EmployeesOnPosition.Empid = id;
        _context.Add(model.EmployeesOnPosition);
        await _context.SaveChangesAsync();
        return Redirect("/Employees/Edit/"+id);
    }
    
    [Route ("ViewModels/DelPos/{empid?}/{posid}")]
    public async Task<IActionResult> DelPos(long empid, long posid)
    {
        var employees = _context.Employees.Include("EmployeesOnPositions.Pos").Where(emp=>emp.Id==empid);
        var emp = await employees.FirstAsync();
        ViewData["Pos"] = new SelectList(_context.Positions, "Id", "Name");
        var viewmodel = new ViewModel
        {
            Employee = emp,
            EmployeesOnPosition = new EmployeesOnPosition {Empid = emp.Id, Posid = posid, Pos = await _context.Positions.FindAsync(posid)}
        };
        return View(viewmodel);
    }
    
    [HttpPost, ActionName("DelPos")]
    [ValidateAntiForgeryToken]
    [Route ("ViewModels/DelPos/{empid?}/{posid}")]
    public async Task<IActionResult> DelPosConfirmed(long empid, long posid)
    {
        var emponpos = await _context.EmployeesOnPositions.FindAsync(empid, posid);
        _context.EmployeesOnPositions.Remove(emponpos);
        await _context.SaveChangesAsync();
        return Redirect($"/ViewModels/AddPos/{empid}");
    }

    public async Task<IActionResult> ViewSchedule(long empid)
    {
        var viewmodel = new ViewModel
        {
            Employee = await _context.Employees
                .Include("Schedules.Serviceprovision.Cli")
                .Include("Schedules.Serviceprovision.Ser")
                .Where(emp => emp.Id == empid)
                .FirstOrDefaultAsync()
        };
        return View(viewmodel);
    }

    // [Route("ViewModels/AddSerProv/{cliid?}/{serid}")]
    // 
    // public async Task<IActionResult> AddSerProv(long cliid, [Bind("")])
    // {
    //     
    //     return View();
    // }
    //
    // [HttpPost, ActionName("AddSerProv")]
    // [Route("ViewModels/AddSerProv/{cliid?}/{serid}")]
    // public async Task<IActionResult> AddSerProvCli(long cliid, long serid)
    // {
    //     var viewModels = new List<ViewModel>();
    //     var clients = await _context.Clients.ToListAsync();
    //     foreach (var client in clients)
    //     {
    //         viewModels.Add(new ViewModel {Client = client});
    //     }
    //
    //     return View(viewModels);
    // }
    
}