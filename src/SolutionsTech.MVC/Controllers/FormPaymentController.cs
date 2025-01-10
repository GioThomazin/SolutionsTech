using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Data.Context;

namespace SolutionsTech.MVC.Controllers
{
	public class FormPaymentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormPaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormPayment
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormPayment.ToListAsync());
        }

        // GET: FormPayment/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formPayment = await _context.FormPayment
                .FirstOrDefaultAsync(m => m.IdFormPayment == id);
            if (formPayment == null)
            {
                return NotFound();
            }

            return View(formPayment);
        }

        // GET: FormPayment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormPayment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFormPayment,Name,DtCreate,Active")] FormPayment formPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formPayment);
        }

        // GET: FormPayment/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formPayment = await _context.FormPayment.FindAsync(id);
            if (formPayment == null)
            {
                return NotFound();
            }
            return View(formPayment);
        }

        // POST: FormPayment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdFormPayment,Name,DtCreate,Active")] FormPayment formPayment)
        {
            if (id != formPayment.IdFormPayment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormPaymentExists(formPayment.IdFormPayment))
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
            return View(formPayment);
        }

        // GET: FormPayment/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formPayment = await _context.FormPayment
                .FirstOrDefaultAsync(m => m.IdFormPayment == id);
            if (formPayment == null)
            {
                return NotFound();
            }

            return View(formPayment);
        }

        // POST: FormPayment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var formPayment = await _context.FormPayment.FindAsync(id);
            if (formPayment != null)
            {
                _context.FormPayment.Remove(formPayment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormPaymentExists(long id)
        {
            return _context.FormPayment.Any(e => e.IdFormPayment == id);
        }
    }
}
