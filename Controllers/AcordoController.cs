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
    public class AcordoController : Controller
    {
        private readonly ProjectDealContext _context;

        public AcordoController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: Acordo
        public async Task<IActionResult> Index()
        {
              return _context.Acordos != null ? 
                          View(await _context.Acordos.ToListAsync()) :
                          Problem("Entity set 'ProjectDealContext.Acordos'  is null.");
        }

        // GET: Acordo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
                .FirstOrDefaultAsync(m => m.AcordoId == id);
            if (acordo == null)
            {
                return NotFound();
            }

            return View(acordo);
        }

        // GET: Acordo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acordo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcordoId")] Acordo acordo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acordo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acordo);
        }

        // GET: Acordo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos.FindAsync(id);
            if (acordo == null)
            {
                return NotFound();
            }
            return View(acordo);
        }

        // POST: Acordo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcordoId")] Acordo acordo)
        {
            if (id != acordo.AcordoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acordo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcordoExists(acordo.AcordoId))
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
            return View(acordo);
        }

        // GET: Acordo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
                .FirstOrDefaultAsync(m => m.AcordoId == id);
            if (acordo == null)
            {
                return NotFound();
            }

            return View(acordo);
        }

        // POST: Acordo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClientCancela(int id)
        {
            if (_context.Acordos == null)
            {
                return Problem("Entity set 'ProjectDealContext.Acordos'  is null.");
            }
            var acordo = await _context.Acordos.FindAsync(id);
            acordo.Servico = _context.Servicos.Find(acordo.FkServico);
            
            if (acordo != null)
            {
                _context.Acordos.Remove(acordo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcordoExists(int id)
        {
          return (_context.Acordos?.Any(e => e.AcordoId == id)).GetValueOrDefault();
        }
    }
}
