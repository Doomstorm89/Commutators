using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Commutators.Data;
using Commutators.Models.Entities;

namespace Commutators.Controllers
{
    public class CommutatorController : Controller
    {
        private readonly CommutatorsContext _context;

        public CommutatorController(CommutatorsContext context)
        {
            _context = context;
        }

        // GET: Commutator
        public async Task<IActionResult> Index()
        {
            return _context.BaseCommutator != null ?
                        View(await _context.BaseCommutator.ToListAsync()) :
                        Problem("Entity set 'CommutatorsContext.BaseCommutator'  is null.");
        }

        // GET: Commutator/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.BaseCommutator == null)
            {
                return NotFound();
            }

            var baseCommutator = await _context.BaseCommutator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseCommutator == null)
            {
                return NotFound();
            }

            return View(baseCommutator);
        }

        // GET: Commutator/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Commutator/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Model,IP,MAC,SerialNumber,InventoryNumber,PurchaseDate,InstallDate,Floor,Comment")] BaseCommutator baseCommutator)
        {
            try
            {
                baseCommutator.Id = Guid.NewGuid();
                var vlanController = new VLANController();
                baseCommutator.VLANController = vlanController;
                _context.Add(baseCommutator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Commutator/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.BaseCommutator == null)
            {
                return NotFound();
            }

            var baseCommutator = await _context.BaseCommutator.FindAsync(id);
            if (baseCommutator == null)
            {
                return NotFound();
            }
            return View(baseCommutator);
        }

        // POST: Commutator/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Model,IP,MAC,SerialNumber,InventoryNumber,PurchaseDate,InstallDate,Floor,Comment")] BaseCommutator baseCommutator)
        {
            if (id != baseCommutator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseCommutator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseCommutatorExists(baseCommutator.Id))
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
            return View(baseCommutator);
        }

        // GET: Commutator/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.BaseCommutator == null)
            {
                return NotFound();
            }

            var baseCommutator = await _context.BaseCommutator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseCommutator == null)
            {
                return NotFound();
            }

            return View(baseCommutator);
        }

        // POST: Commutator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.BaseCommutator == null)
            {
                return Problem("Entity set 'CommutatorsContext.BaseCommutator'  is null.");
            }
            var baseCommutator = await _context.BaseCommutator.FindAsync(id);
            if (baseCommutator != null)
            {
                _context.BaseCommutator.Remove(baseCommutator);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseCommutatorExists(Guid id)
        {
            return (_context.BaseCommutator?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
