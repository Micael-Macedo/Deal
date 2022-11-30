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
    public class FotosController : Controller
    {
        private readonly ProjectDealContext _context;

        public FotosController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: Fotos
        public async Task<IActionResult> Index()
        {
            var projectDealContext = _context.Fotos.Include(f => f.Portfolio);
            return View(await projectDealContext.ToListAsync());
        }

        // GET: Fotos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fotos == null)
            {
                return NotFound();
            }

            var foto = await _context.Fotos
                .Include(f => f.Portfolio)
                .FirstOrDefaultAsync(m => m.FotoId == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // GET: Fotos/Create
        public IActionResult Create(int? id)
        {
            if (id == null || _context.Fotos == null)
            {
                return NotFound();
            }
            ViewBag.portfolioIdFoto = id;
            return View();
        }

        // POST: Fotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FotoId,FotoPrestador,FkPortfolio")] Foto foto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Portfolios", new {id = foto.FkPortfolio});
            }
            ViewData["FkPortfolio"] = new SelectList(_context.Portfolios, "PortfolioId", "PortfolioId", foto.FkPortfolio);
            return View(foto);
        }

        // GET: Fotos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fotos == null)
            {
                return NotFound();
            }

            var foto = await _context.Fotos.FindAsync(id);
            if (foto == null)
            {
                return NotFound();
            }
            ViewData["FkPortfolio"] = new SelectList(_context.Portfolios, "PortfolioId", "PortfolioId", foto.FkPortfolio);
            return View(foto);
        }

        // POST: Fotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FotoId,FotoPrestador,FkPortfolio")] Foto foto)
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
            ViewData["FkPortfolio"] = new SelectList(_context.Portfolios, "PortfolioId", "PortfolioId", foto.FkPortfolio);
            return View(foto);
        }

        // GET: Fotos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fotos == null)
            {
                return NotFound();
            }

            var foto = await _context.Fotos
                .Include(f => f.Portfolio)
                .FirstOrDefaultAsync(m => m.FotoId == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // POST: Fotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fotos == null)
            {
                return Problem("Entity set 'ProjectDealContext.Fotos'  is null.");
            }
            var foto = await _context.Fotos.FindAsync(id);
            if (foto != null)
            {
                _context.Fotos.Remove(foto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotoExists(int id)
        {
          return _context.Fotos.Any(e => e.FotoId == id);
        }
    }
}
