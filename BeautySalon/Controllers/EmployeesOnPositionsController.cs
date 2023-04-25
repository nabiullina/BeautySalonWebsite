using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeautySalon.Data.Models;

namespace BeautySalon.Controllers
{
    public class EmployeesOnPositionsController : Controller
    {
        private readonly BeautysalonContext _context;

        public EmployeesOnPositionsController(BeautysalonContext context)
        {
            _context = context;
        }

        // GET: EmployeesOnPositions
        public async Task<IActionResult> Index()
        {
              return _context.EmployeesOnPositions != null ? 
                          View(await _context.EmployeesOnPositions.ToListAsync()) :
                          Problem("Entity set 'BeautysalonContext.EmployeesOnPositions'  is null.");
        }

        // GET: EmployeesOnPositions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.EmployeesOnPositions == null)
            {
                return NotFound();
            }

            var employeesOnPositions = await _context.EmployeesOnPositions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeesOnPositions == null)
            {
                return NotFound();
            }

            return View(employeesOnPositions);
        }

        // GET: EmployeesOnPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeesOnPositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Empid,Posid")] EmployeesOnPosition employeesOnPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeesOnPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeesOnPosition);
        }

        // GET: EmployeesOnPositions/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.EmployeesOnPositions == null)
            {
                return NotFound();
            }

            var employeesOnPositions = await _context.EmployeesOnPositions.FindAsync(id);
            if (employeesOnPositions == null)
            {
                return NotFound();
            }
            return View(employeesOnPositions);
        }

        // POST: EmployeesOnPositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Empid,Posid")] EmployeesOnPosition employeesOnPosition)
        {
            if (id != employeesOnPosition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeesOnPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesOnPositionsExists(employeesOnPosition.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeesOnPosition);
        }

        // GET: EmployeesOnPositions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.EmployeesOnPositions == null)
            {
                return NotFound();
            }

            var employeesOnPositions = await _context.EmployeesOnPositions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeesOnPositions == null)
            {
                return NotFound();
            }

            return View(employeesOnPositions);
        }

        // POST: EmployeesOnPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.EmployeesOnPositions == null)
            {
                return Problem("Entity set 'BeautysalonContext.EmployeesOnPositions'  is null.");
            }
            var employeesOnPositions = await _context.EmployeesOnPositions.FindAsync(id);
            if (employeesOnPositions != null)
            {
                _context.EmployeesOnPositions.Remove(employeesOnPositions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesOnPositionsExists(long id)
        {
          return (_context.EmployeesOnPositions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
