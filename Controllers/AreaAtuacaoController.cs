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
    public class AreaAtuacaoController : Controller
    {
        private readonly ProjectDealContext _context;

        public AreaAtuacaoController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: AreaAtuacao
        public async Task<IActionResult> Index()
        {
              return _context.AreaAtuacao != null ? 
                          View(await _context.AreaAtuacao.ToListAsync()) :
                          Problem("Entity set 'ProjectDealContext.AreaAtuacao'  is null.");
        }

        // GET: AreaAtuacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AreaAtuacao == null)
            {
                return NotFound();
            }

            var areaAtuacao = await _context.AreaAtuacao
                .FirstOrDefaultAsync(m => m.AreaAtuacaoId == id);
            if (areaAtuacao == null)
            {
                return NotFound();
            }

            return View(areaAtuacao);
        }

        // GET: AreaAtuacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AreaAtuacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AreaAtuacaoId,Atuacao")] AreaAtuacao areaAtuacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaAtuacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(areaAtuacao);
        }

        // GET: AreaAtuacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AreaAtuacao == null)
            {
                return NotFound();
            }

            var areaAtuacao = await _context.AreaAtuacao.FindAsync(id);
            if (areaAtuacao == null)
            {
                return NotFound();
            }
            return View(areaAtuacao);
        }

        // POST: AreaAtuacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AreaAtuacaoId,Atuacao")] AreaAtuacao areaAtuacao)
        {
            if (id != areaAtuacao.AreaAtuacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaAtuacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaAtuacaoExists(areaAtuacao.AreaAtuacaoId))
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
            return View(areaAtuacao);
        }

        // GET: AreaAtuacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AreaAtuacao == null)
            {
                return NotFound();
            }

            var areaAtuacao = await _context.AreaAtuacao
                .FirstOrDefaultAsync(m => m.AreaAtuacaoId == id);
            if (areaAtuacao == null)
            {
                return NotFound();
            }

            return View(areaAtuacao);
        }

        // POST: AreaAtuacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AreaAtuacao == null)
            {
                return Problem("Entity set 'ProjectDealContext.AreaAtuacao'  is null.");
            }
            var areaAtuacao = await _context.AreaAtuacao.FindAsync(id);
            if (areaAtuacao != null)
            {
                _context.AreaAtuacao.Remove(areaAtuacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaAtuacaoExists(int id)
        {
          return (_context.AreaAtuacao?.Any(e => e.AreaAtuacaoId == id)).GetValueOrDefault();
        }
    }
}
