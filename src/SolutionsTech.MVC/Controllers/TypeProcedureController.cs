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
    public class TypeProcedureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeProcedureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeProcedure
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeProcedure.ToListAsync());
        }

        // GET: TypeProcedure/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProcedure = await _context.TypeProcedure
                .FirstOrDefaultAsync(m => m.IdTypeProcedure == id);
            if (typeProcedure == null)
            {
                return NotFound();
            }

            return View(typeProcedure);
        }

        // GET: TypeProcedure/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeProcedure/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTypeProcedure,Name,Value")] TypeProcedure typeProcedure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeProcedure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeProcedure);
        }

        // GET: TypeProcedure/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProcedure = await _context.TypeProcedure.FindAsync(id);
            if (typeProcedure == null)
            {
                return NotFound();
            }
            return View(typeProcedure);
        }

        // POST: TypeProcedure/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdTypeProcedure,Name,Value")] TypeProcedure typeProcedure)
        {
            if (id != typeProcedure.IdTypeProcedure)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeProcedure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeProcedureExists(typeProcedure.IdTypeProcedure))
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
            return View(typeProcedure);
        }

        // GET: TypeProcedure/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProcedure = await _context.TypeProcedure
                .FirstOrDefaultAsync(m => m.IdTypeProcedure == id);
            if (typeProcedure == null)
            {
                return NotFound();
            }

            return View(typeProcedure);
        }

        // POST: TypeProcedure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var typeProcedure = await _context.TypeProcedure.FindAsync(id);
            if (typeProcedure != null)
            {
                _context.TypeProcedure.Remove(typeProcedure);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeProcedureExists(long id)
        {
            return _context.TypeProcedure.Any(e => e.IdTypeProcedure == id);
        }
    }
}
