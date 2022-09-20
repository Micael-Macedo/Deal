using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Deal.Models;

namespace Deal.Controllers
{
    public class FotoController : Controller
    {
        private readonly ProjectDealContext _context;

        public FotoController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: Foto
        public async Task<IActionResult> Index()
        {
              return _context.Foto != null ? 
                          View(await _context.Foto.ToListAsync()) :
                          Problem("Entity set 'ProjectDealContext.Foto'  is null.");
        }

        // GET: Foto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Foto == null)
            {
                return NotFound();
            }

            var foto = await _context.Foto
                .FirstOrDefaultAsync(m => m.FotoId == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // GET: Foto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FotoId,FotoPortfolio")] Foto foto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foto);
        }

        // GET: Foto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Foto == null)
            {
                return NotFound();
            }

            var foto = await _context.Foto.FindAsync(id);
            if (foto == null)
            {
                return NotFound();
            }
            return View(foto);
        }

        // POST: Foto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FotoId,FotoPortfolio")] Foto foto)
        {
            if (id != foto.FotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotoExists(foto.FotoId))
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
            return View(foto);
        }

        // GET: Foto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Foto == null)
            {
                return NotFound();
            }

            var foto = await _context.Foto
                .FirstOrDefaultAsync(m => m.FotoId == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // POST: Foto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Foto == null)
            {
                return Problem("Entity set 'ProjectDealContext.Foto'  is null.");
            }
            var foto = await _context.Foto.FindAsync(id);
            if (foto != null)
            {
                _context.Foto.Remove(foto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotoExists(int id)
        {
          return (_context.Foto?.Any(e => e.FotoId == id)).GetValueOrDefault();
        }
    }
}
