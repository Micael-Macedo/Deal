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
    public class PrestadorController : Controller
    {
        private readonly ProjectDealContext _context;

        public PrestadorController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: Prestador
        public async Task<IActionResult> Index()
        {
              return _context.Prestadores != null ? 
                          View(await _context.Prestadores.ToListAsync()) :
                          Problem("Entity set 'ProjectDealContext.Prestadores'  is null.");
        }

        // GET: Prestador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prestadores == null)
            {
                return NotFound();
            }

            var prestador = await _context.Prestadores
                .FirstOrDefaultAsync(m => m.PrestadorId == id);
            if (prestador == null)
            {
                return NotFound();
            }

            return View(prestador);
        }

        // GET: Prestador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prestador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrestadorId,Nome,Cpf,Idade,Endereco,Cep,Telefone,Senha,Email,QtdServicoRealizados")] Prestador prestador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prestador);
        }

        // GET: Prestador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prestadores == null)
            {
                return NotFound();
            }

            var prestador = await _context.Prestadores.FindAsync(id);
            if (prestador == null)
            {
                return NotFound();
            }
            return View(prestador);
        }

        // POST: Prestador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrestadorId,Nome,Cpf,Idade,Endereco,Cep,Telefone,Senha,Email,QtdServicoRealizados")] Prestador prestador)
        {
            if (id != prestador.PrestadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestadorExists(prestador.PrestadorId))
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
            return View(prestador);
        }

        // GET: Prestador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prestadores == null)
            {
                return NotFound();
            }

            var prestador = await _context.Prestadores
                .FirstOrDefaultAsync(m => m.PrestadorId == id);
            if (prestador == null)
            {
                return NotFound();
            }

            return View(prestador);
        }

        // POST: Prestador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prestadores == null)
            {
                return Problem("Entity set 'ProjectDealContext.Prestadores'  is null.");
            }
            var prestador = await _context.Prestadores.FindAsync(id);
            if (prestador != null)
            {
                _context.Prestadores.Remove(prestador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestadorExists(int id)
        {
          return (_context.Prestadores?.Any(e => e.PrestadorId == id)).GetValueOrDefault();
        }
    }
}
