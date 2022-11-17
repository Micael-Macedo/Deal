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
    public class NotasClientesController : Controller
    {
        private readonly ProjectDealContext _context;

        public NotasClientesController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: NotasClientes
        public async Task<IActionResult> Index()
        {
            var projectDealContext = _context.NotaClientes.Include(n => n.Cliente);
            return View(await projectDealContext.ToListAsync());
        }

        // GET: NotasClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NotaClientes == null)
            {
                return NotFound();
            }

            var notaCliente = await _context.NotaClientes
                .Include(n => n.Cliente)
                .FirstOrDefaultAsync(m => m.NotaClienteId == id);
            if (notaCliente == null)
            {
                return NotFound();
            }

            return View(notaCliente);
        }

        // GET: NotasClientes/Create
        public IActionResult Create()
        {
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            return View();
        }

        // POST: NotasClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotaClienteId,Avaliacao,FkCliente")] NotaCliente notaCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notaCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", notaCliente.FkCliente);
            return View(notaCliente);
        }

        // GET: NotasClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NotaClientes == null)
            {
                return NotFound();
            }

            var notaCliente = await _context.NotaClientes.FindAsync(id);
            if (notaCliente == null)
            {
                return NotFound();
            }
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", notaCliente.FkCliente);
            return View(notaCliente);
        }

        // POST: NotasClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotaClienteId,Avaliacao,FkCliente")] NotaCliente notaCliente)
        {
            if (id != notaCliente.NotaClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaClienteExists(notaCliente.NotaClienteId))
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
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", notaCliente.FkCliente);
            return View(notaCliente);
        }

        // GET: NotasClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NotaClientes == null)
            {
                return NotFound();
            }

            var notaCliente = await _context.NotaClientes
                .Include(n => n.Cliente)
                .FirstOrDefaultAsync(m => m.NotaClienteId == id);
            if (notaCliente == null)
            {
                return NotFound();
            }

            return View(notaCliente);
        }

        // POST: NotasClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NotaClientes == null)
            {
                return Problem("Entity set 'ProjectDealContext.NotaClientes'  is null.");
            }
            var notaCliente = await _context.NotaClientes.FindAsync(id);
            if (notaCliente != null)
            {
                _context.NotaClientes.Remove(notaCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaClienteExists(int id)
        {
          return _context.NotaClientes.Any(e => e.NotaClienteId == id);
        }
    }
}
