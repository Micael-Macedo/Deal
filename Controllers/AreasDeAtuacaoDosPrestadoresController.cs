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
    public class AreasDeAtuacaoDosPrestadoresController : Controller
    {
        private readonly ProjectDealContext _context;

        public AreasDeAtuacaoDosPrestadoresController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: AreasDeAtuacaoDosPrestadores
        public async Task<IActionResult> Index()
        {
            var projectDealContext = _context.AreasDeAtuacaoDoPrestador.Include(a => a.AreaAtuacao).Include(a => a.Prestador);
            return View(await projectDealContext.ToListAsync());
        }

        // GET: AreasDeAtuacaoDosPrestadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AreasDeAtuacaoDoPrestador == null)
            {
                return NotFound();
            }

            var areasDeAtuacaoDoPrestador = await _context.AreasDeAtuacaoDoPrestador
                .Include(a => a.AreaAtuacao)
                .Include(a => a.Prestador)
                .FirstOrDefaultAsync(m => m.AreasDeAtuacaoDoPrestadorId == id);
            if (areasDeAtuacaoDoPrestador == null)
            {
                return NotFound();
            }

            return View(areasDeAtuacaoDoPrestador);
        }

        // GET: AreasDeAtuacaoDosPrestadores/Create
        public IActionResult Create()
        {
            ViewData["FkAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "Atuacao");
            ViewData["FkPrestador"] = new SelectList(_context.Prestadores, "PrestadorId", "PrestadorId");
            return View();
        }

        // POST: AreasDeAtuacaoDosPrestadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AreasDeAtuacaoDoPrestadorId,FkPrestador,FkAreaAtuacao")] AreasDeAtuacaoDoPrestador areasDeAtuacaoDoPrestador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areasDeAtuacaoDoPrestador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "AreaAtuacaoId", areasDeAtuacaoDoPrestador.FkAreaAtuacao);
            ViewData["FkPrestador"] = new SelectList(_context.Prestadores, "PrestadorId", "PrestadorId", areasDeAtuacaoDoPrestador.FkPrestador);
            return View(areasDeAtuacaoDoPrestador);
        }

        // GET: AreasDeAtuacaoDosPrestadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AreasDeAtuacaoDoPrestador == null)
            {
                return NotFound();
            }

            var areasDeAtuacaoDoPrestador = await _context.AreasDeAtuacaoDoPrestador.FindAsync(id);
            if (areasDeAtuacaoDoPrestador == null)
            {
                return NotFound();
            }
            ViewData["FkAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "AreaAtuacaoId", areasDeAtuacaoDoPrestador.FkAreaAtuacao);
            ViewData["FkPrestador"] = new SelectList(_context.Prestadores, "PrestadorId", "PrestadorId", areasDeAtuacaoDoPrestador.FkPrestador);
            return View(areasDeAtuacaoDoPrestador);
        }

        // POST: AreasDeAtuacaoDosPrestadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AreasDeAtuacaoDoPrestadorId,FkPrestador,FkAreaAtuacao")] AreasDeAtuacaoDoPrestador areasDeAtuacaoDoPrestador)
        {
            if (id != areasDeAtuacaoDoPrestador.AreasDeAtuacaoDoPrestadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areasDeAtuacaoDoPrestador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreasDeAtuacaoDoPrestadorExists(areasDeAtuacaoDoPrestador.AreasDeAtuacaoDoPrestadorId))
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
            ViewData["FkAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "AreaAtuacaoId", areasDeAtuacaoDoPrestador.FkAreaAtuacao);
            ViewData["FkPrestador"] = new SelectList(_context.Prestadores, "PrestadorId", "PrestadorId", areasDeAtuacaoDoPrestador.FkPrestador);
            return View(areasDeAtuacaoDoPrestador);
        }

        // GET: AreasDeAtuacaoDosPrestadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AreasDeAtuacaoDoPrestador == null)
            {
                return NotFound();
            }

            var areasDeAtuacaoDoPrestador = await _context.AreasDeAtuacaoDoPrestador
                .Include(a => a.AreaAtuacao)
                .Include(a => a.Prestador)
                .FirstOrDefaultAsync(m => m.AreasDeAtuacaoDoPrestadorId == id);
            if (areasDeAtuacaoDoPrestador == null)
            {
                return NotFound();
            }

            return View(areasDeAtuacaoDoPrestador);
        }

        // POST: AreasDeAtuacaoDosPrestadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AreasDeAtuacaoDoPrestador == null)
            {
                return Problem("Entity set 'ProjectDealContext.AreasDeAtuacaoDoPrestador'  is null.");
            }
            var areasDeAtuacaoDoPrestador = await _context.AreasDeAtuacaoDoPrestador.FindAsync(id);
            if (areasDeAtuacaoDoPrestador != null)
            {
                _context.AreasDeAtuacaoDoPrestador.Remove(areasDeAtuacaoDoPrestador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreasDeAtuacaoDoPrestadorExists(int id)
        {
          return _context.AreasDeAtuacaoDoPrestador.Any(e => e.AreasDeAtuacaoDoPrestadorId == id);
        }
    }
}
