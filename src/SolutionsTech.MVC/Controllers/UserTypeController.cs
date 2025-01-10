using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Data.Context;

namespace SolutionsTech.MVC.Controllers
{
	public class UserTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserType
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserType.ToListAsync());
        }

        // GET: UserType/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userType = await _context.UserType
                .FirstOrDefaultAsync(m => m.IdUserType == id);
            if (userType == null)
            {
                return NotFound();
            }

            return View(userType);
        }

        // GET: UserType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUserType,Name,Active")] UserType userType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userType);
        }

        // GET: UserType/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userType = await _context.UserType.FindAsync(id);
            if (userType == null)
            {
                return NotFound();
            }
            return View(userType);
        }

        // POST: UserType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdUserType,Name,Active")] UserType userType)
        {
            if (id != userType.IdUserType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTypeExists(userType.IdUserType))
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
            return View(userType);
        }

        // GET: UserType/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userType = await _context.UserType
                .FirstOrDefaultAsync(m => m.IdUserType == id);
            if (userType == null)
            {
                return NotFound();
            }

            return View(userType);
        }

        // POST: UserType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var userType = await _context.UserType.FindAsync(id);
            if (userType != null)
            {
                _context.UserType.Remove(userType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTypeExists(long id)
        {
            return _context.UserType.Any(e => e.IdUserType == id);
        }
    }
}
