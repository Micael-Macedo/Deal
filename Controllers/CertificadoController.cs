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
    public class CertificadoController : Controller
    {
        private readonly ProjectDealContext _context;

        public CertificadoController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: Certificado
        public async Task<IActionResult> Index()
        {
              return _context.Certificado != null ? 
                          View(await _context.Certificado.ToListAsync()) :
                          Problem("Entity set 'ProjectDealContext.Certificado'  is null.");
        }

        // GET: Certificado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Certificado == null)
            {
                return NotFound();
            }

            var certificado = await _context.Certificado
                .FirstOrDefaultAsync(m => m.CertificadoId == id);
            if (certificado == null)
            {
                return NotFound();
            }
            return View(certificado);
        }

        // GET: Certificado/Create
        public IActionResult Create(int? id)
        {
            if (id == null || _context.Portfolios == null)
            {
                return NotFound();
            }
            ViewBag.portfolioId = id;
            return View();
        }

        // POST: Certificado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CertificadoId,CertificadoFotoPortfolio")] Certificado certificado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certificado);
        }

        // GET: Certificado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Certificado == null)
            {
                return NotFound();
            }

            var certificado = await _context.Certificado.FindAsync(id);
            if (certificado == null)
            {
                return NotFound();
            }
            return View(certificado);
        }

        // POST: Certificado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CertificadoId,CertificadoFotoPortfolio")] Certificado certificado)
        {
            if (id != certificado.CertificadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificadoExists(certificado.CertificadoId))
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
            return View(certificado);
        }

        // GET: Certificado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Certificado == null)
            {
                return NotFound();
            }

            var certificado = await _context.Certificado
                .FirstOrDefaultAsync(m => m.CertificadoId == id);
            if (certificado == null)
            {
                return NotFound();
            }

            return View(certificado);
        }

        // POST: Certificado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Certificado == null)
            {
                return Problem("Entity set 'ProjectDealContext.Certificado'  is null.");
            }
            var certificado = await _context.Certificado.FindAsync(id);
            if (certificado != null)
            {
                _context.Certificado.Remove(certificado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificadoExists(int id)
        {
          return (_context.Certificado?.Any(e => e.CertificadoId == id)).GetValueOrDefault();
        }
    }
}
