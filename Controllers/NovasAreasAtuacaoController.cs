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
    public class NovasAreasAtuacaoController : Controller
    {
        private readonly ProjectDealContext _context;

        public NovasAreasAtuacaoController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: NovasAreasAtuacao
        public async Task<IActionResult> Index()
        {
            return _context.NovasAreasAtuacoes != null ?
                        View(await _context.NovasAreasAtuacoes.ToListAsync()) :
                        Problem("Entity set 'ProjectDealContext.NovasAreasAtuacoes'  is null.");
        }

        // GET: NovasAreasAtuacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NovasAreasAtuacoes == null)
            {
                return NotFound();
            }

            var novaAreaAtuacao = await _context.NovasAreasAtuacoes
                .FirstOrDefaultAsync(m => m.NovaAreaAtuacaoId == id);
            if (novaAreaAtuacao == null)
            {
                return NotFound();
            }

            return View(novaAreaAtuacao);
        }

        // GET: NovasAreasAtuacao/Create
        public async Task<IActionResult> Create(int? id)
        {
            Prestador prestador = await _context.Prestadores.FindAsync(id);
            ViewBag.prestador = prestador;
            ViewBag.PrestadorId = id;
            return View();
        }

        // POST: NovasAreasAtuacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NovaAreaAtuacaoId,Atuacao,isOnline")] NovaAreaAtuacao novaAreaAtuacao, int PrestadorId)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novaAreaAtuacao);
                await _context.SaveChangesAsync();

                return RedirectToAction("Home", "Prestadores", new { id = PrestadorId });
            }
            return View(novaAreaAtuacao);
        }

        // GET: NovasAreasAtuacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NovasAreasAtuacoes == null)
            {
                return NotFound();
            }

            var novaAreaAtuacao = await _context.NovasAreasAtuacoes.FindAsync(id);
            if (novaAreaAtuacao == null)
            {
                return NotFound();
            }
            return View(novaAreaAtuacao);
        }

        // POST: NovasAreasAtuacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NovaAreaAtuacaoId,Atuacao,isOnline")] NovaAreaAtuacao novaAreaAtuacao)
        {
            if (id != novaAreaAtuacao.NovaAreaAtuacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novaAreaAtuacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovaAreaAtuacaoExists(novaAreaAtuacao.NovaAreaAtuacaoId))
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
            return View(novaAreaAtuacao);
        }

        // GET: NovasAreasAtuacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NovasAreasAtuacoes == null)
            {
                return NotFound();
            }

            var novaAreaAtuacao = await _context.NovasAreasAtuacoes
                .FirstOrDefaultAsync(m => m.NovaAreaAtuacaoId == id);
            if (novaAreaAtuacao == null)
            {
                return NotFound();
            }

            return View(novaAreaAtuacao);
        }

        // POST: NovasAreasAtuacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NovasAreasAtuacoes == null)
            {
                return Problem("Entity set 'ProjectDealContext.NovasAreasAtuacoes'  is null.");
            }
            var novaAreaAtuacao = await _context.NovasAreasAtuacoes.FindAsync(id);
            if (novaAreaAtuacao != null)
            {
                _context.NovasAreasAtuacoes.Remove(novaAreaAtuacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovaAreaAtuacaoExists(int id)
        {
            return (_context.NovasAreasAtuacoes?.Any(e => e.NovaAreaAtuacaoId == id)).GetValueOrDefault();
        }
    }
}
