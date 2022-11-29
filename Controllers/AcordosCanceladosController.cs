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
    public class AcordosCanceladosController : Controller
    {
        private readonly ProjectDealContext _context;

        public AcordosCanceladosController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: AcordosCancelados
        public async Task<IActionResult> Index()
        {
            var projectDealContext = _context.AcordosCancelados.Include(a => a.Acordo);
            return View(await projectDealContext.ToListAsync());
        }

        // GET: AcordosCancelados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AcordosCancelados == null)
            {
                return NotFound();
            }

            var acordoCancelado = await _context.AcordosCancelados
                .Include(a => a.Acordo)
                .FirstOrDefaultAsync(m => m.AcordoCanceladoId == id);
            if (acordoCancelado == null)
            {
                return NotFound();
            }

            return View(acordoCancelado);
        }

        // GET: AcordosCancelados/Create
        public IActionResult Create()
        {
            ViewData["AcordoFk"] = new SelectList(_context.Acordos, "AcordoId", "AcordoId");
            return View();
        }

        // POST: AcordosCancelados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcordoCanceladoId,Justificativa,AcordoFk")] AcordoCancelado acordoCancelado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acordoCancelado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcordoFk"] = new SelectList(_context.Acordos, "AcordoId", "AcordoId", acordoCancelado.AcordoFk);
            return View(acordoCancelado);
        }

        // GET: AcordosCancelados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AcordosCancelados == null)
            {
                return NotFound();
            }

            var acordoCancelado = await _context.AcordosCancelados.FindAsync(id);
            if (acordoCancelado == null)
            {
                return NotFound();
            }
            ViewData["AcordoFk"] = new SelectList(_context.Acordos, "AcordoId", "AcordoId", acordoCancelado.AcordoFk);
            return View(acordoCancelado);
        }

        // POST: AcordosCancelados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcordoCanceladoId,Justificativa,AcordoFk")] AcordoCancelado acordoCancelado)
        {
            if (id != acordoCancelado.AcordoCanceladoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acordoCancelado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcordoCanceladoExists(acordoCancelado.AcordoCanceladoId))
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
            ViewData["AcordoFk"] = new SelectList(_context.Acordos, "AcordoId", "AcordoId", acordoCancelado.AcordoFk);
            return View(acordoCancelado);
        }

        // GET: AcordosCancelados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AcordosCancelados == null)
            {
                return NotFound();
            }

            var acordoCancelado = await _context.AcordosCancelados
                .Include(a => a.Acordo)
                .FirstOrDefaultAsync(m => m.AcordoCanceladoId == id);
            if (acordoCancelado == null)
            {
                return NotFound();
            }

            return View(acordoCancelado);
        }

        // POST: AcordosCancelados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AcordosCancelados == null)
            {
                return Problem("Entity set 'ProjectDealContext.AcordosCancelados'  is null.");
            }
            var acordoCancelado = await _context.AcordosCancelados.FindAsync(id);
            if (acordoCancelado != null)
            {
                _context.AcordosCancelados.Remove(acordoCancelado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcordoCanceladoExists(int id)
        {
          return _context.AcordosCancelados.Any(e => e.AcordoCanceladoId == id);
        }
    }
}
