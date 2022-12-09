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
    public class NotasPrestadoresController : Controller
    {
        private readonly ProjectDealContext _context;

        public NotasPrestadoresController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: NotasPrestadores
        public async Task<IActionResult> Index()
        {
            var projectDealContext = _context.NotaPrestadores.Include(n => n.Prestador);
            return View(await projectDealContext.ToListAsync());
        }

        // GET: NotasPrestadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NotaPrestadores == null)
            {
                return NotFound();
            }

            var notaPrestador = await _context.NotaPrestadores
                .Include(n => n.Prestador)
                .FirstOrDefaultAsync(m => m.NotaPrestadorId == id);
            if (notaPrestador == null)
            {
                return NotFound();
            }

            return View(notaPrestador);
        }

        // GET: NotasPrestadores/Create
        public IActionResult Create()
        {
            ViewData["FkPrestador"] = new SelectList(_context.Prestadores, "PrestadorId", "PrestadorId");
            return View();
        }

        // POST: NotasPrestadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotaPrestadorId,Avaliacao,FkPrestador")] NotaPrestador notaPrestador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notaPrestador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkPrestador"] = new SelectList(_context.Prestadores, "PrestadorId", "PrestadorId", notaPrestador.FkPrestador);
            return View(notaPrestador);
        }

        // GET: NotasPrestadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NotaPrestadores == null)
            {
                return NotFound();
            }

            var notaPrestador = await _context.NotaPrestadores.FindAsync(id);
            if (notaPrestador == null)
            {
                return NotFound();
            }
            ViewData["FkPrestador"] = new SelectList(_context.Prestadores, "PrestadorId", "PrestadorId", notaPrestador.FkPrestador);
            return View(notaPrestador);
        }

        // POST: NotasPrestadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotaPrestadorId,Avaliacao,FkPrestador")] NotaPrestador notaPrestador)
        {
            if (id != notaPrestador.NotaPrestadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaPrestador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaPrestadorExists(notaPrestador.NotaPrestadorId))
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
            ViewData["FkPrestador"] = new SelectList(_context.Prestadores, "PrestadorId", "PrestadorId", notaPrestador.FkPrestador);
            return View(notaPrestador);
        }

        // GET: NotasPrestadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NotaPrestadores == null)
            {
                return NotFound();
            }

            var notaPrestador = await _context.NotaPrestadores
                .Include(n => n.Prestador)
                .FirstOrDefaultAsync(m => m.NotaPrestadorId == id);
            if (notaPrestador == null)
            {
                return NotFound();
            }

            return View(notaPrestador);
        }

        // POST: NotasPrestadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NotaPrestadores == null)
            {
                return Problem("Entity set 'ProjectDealContext.NotaPrestadores'  is null.");
            }
            var notaPrestador = await _context.NotaPrestadores.FindAsync(id);
            if (notaPrestador != null)
            {
                _context.NotaPrestadores.Remove(notaPrestador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaPrestadorExists(int id)
        {
          return _context.NotaPrestadores.Any(e => e.NotaPrestadorId == id);
        }
    }
}
