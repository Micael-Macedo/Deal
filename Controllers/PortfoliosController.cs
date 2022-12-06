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
    public class PortfoliosController : Controller
    {
        private readonly ProjectDealContext _context;

        public PortfoliosController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: Portfolios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Portfolios.ToListAsync());
        }

        // GET: Portfolios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Portfolios == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios
                .FirstOrDefaultAsync(m => m.PortfolioId == id);
            if (portfolio == null)
            {
                return NotFound();
            }
            var prestador = await _context.Prestadores.Where(p => p.FkPortfolio == portfolio.PortfolioId).FirstAsync();
            ViewBag.PrestadorId = prestador.PrestadorId;
            ViewData["Fotos"] = _context.Fotos.Where(f => f.FkPortfolio == portfolio.PortfolioId).ToList();
            ViewData["Certificados"] = _context.Certificado.Where(c => c.FkPortfolio == portfolio.PortfolioId).ToList();
            return View(portfolio);
        }

        // GET: Portfolios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Portfolios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PortfolioId,Apresentação,Linkedin,Site,ExperienciaProfissional")] Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                _context.Update(portfolio);
                await _context.SaveChangesAsync();
                Prestador prestador = await _context.Prestadores.FirstAsync(p => p.FkPortfolio == portfolio.PortfolioId);
                return RedirectToAction("Home", "Prestadores", new {id = prestador.PrestadorId});
            }
            return View(portfolio);
        }

        // GET: Portfolios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Portfolios == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }
             Prestador prestador = await _context.Prestadores.FirstAsync(p => p.FkPortfolio == portfolio.PortfolioId);
            return View(portfolio);
        }

        // POST: Portfolios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PortfolioId,Apresentação,Linkedin,Site,ExperienciaProfissional")] Portfolio portfolio)
        {
            if (id != portfolio.PortfolioId)
            {
                return NotFound();
            }
            Prestador prestador = await _context.Prestadores.FirstOrDefaultAsync(p => p.FkPortfolio == portfolio.PortfolioId);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioExists(portfolio.PortfolioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Home", "Prestadores", new {id = prestador.PrestadorId});
            }
            return RedirectToAction("Home", "Prestadores", new {id = prestador.PrestadorId});
        }

        // GET: Portfolios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Portfolios == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios
                .FirstOrDefaultAsync(m => m.PortfolioId == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // POST: Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Portfolios == null)
            {
                return Problem("Entity set 'ProjectDealContext.Portfolios'  is null.");
            }
            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio != null)
            {
                _context.Portfolios.Remove(portfolio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioExists(int id)
        {
          return _context.Portfolios.Any(e => e.PortfolioId == id);
        }
    }
}
