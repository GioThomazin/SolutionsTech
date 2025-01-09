using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.MVC.Data;
using SolutionsTech.MVC.Models;

namespace SolutionsTech.MVC.Controllers
{
    public class SchedulingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchedulingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Scheduling
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Scheduling.Include(s => s.FormPayment).Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Scheduling/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduling = await _context.Scheduling
                .Include(s => s.FormPayment)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.IdScheduling == id);
            if (scheduling == null)
            {
                return NotFound();
            }

            return View(scheduling);
        }

        // GET: Scheduling/Create
        public IActionResult Create()
        {
            ViewData["IdFormPayment"] = new SelectList(_context.FormPayment, "IdFormPayment", "IdFormPayment");
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser");
            return View();
        }

        // POST: Scheduling/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdScheduling,Name,DtCreate,TotalValue,Observation,IdUser,IdFormPayment")] Scheduling scheduling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFormPayment"] = new SelectList(_context.FormPayment, "IdFormPayment", "IdFormPayment", scheduling.IdFormPayment);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", scheduling.IdUser);
            return View(scheduling);
        }

        // GET: Scheduling/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduling = await _context.Scheduling.FindAsync(id);
            if (scheduling == null)
            {
                return NotFound();
            }
            ViewData["IdFormPayment"] = new SelectList(_context.FormPayment, "IdFormPayment", "IdFormPayment", scheduling.IdFormPayment);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", scheduling.IdUser);
            return View(scheduling);
        }

        // POST: Scheduling/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdScheduling,Name,DtCreate,TotalValue,Observation,IdUser,IdFormPayment")] Scheduling scheduling)
        {
            if (id != scheduling.IdScheduling)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchedulingExists(scheduling.IdScheduling))
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
            ViewData["IdFormPayment"] = new SelectList(_context.FormPayment, "IdFormPayment", "IdFormPayment", scheduling.IdFormPayment);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", scheduling.IdUser);
            return View(scheduling);
        }

        // GET: Scheduling/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduling = await _context.Scheduling
                .Include(s => s.FormPayment)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.IdScheduling == id);
            if (scheduling == null)
            {
                return NotFound();
            }

            return View(scheduling);
        }

        // POST: Scheduling/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var scheduling = await _context.Scheduling.FindAsync(id);
            if (scheduling != null)
            {
                _context.Scheduling.Remove(scheduling);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchedulingExists(long id)
        {
            return _context.Scheduling.Any(e => e.IdScheduling == id);
        }
    }
}
