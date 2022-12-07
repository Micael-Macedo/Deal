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
    public class ReportesPrestadoresController : Controller
    {
        private readonly ProjectDealContext _context;

        public ReportesPrestadoresController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: ReportesPrestadores
        public async Task<IActionResult> Index()
        {
            var projectDealContext = _context.ReportesPrestadores.Include(r => r.Cliente);
            return View(await projectDealContext.ToListAsync());
        }

        // GET: ReportesPrestadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReportesPrestadores == null)
            {
                return NotFound();
            }

            var reportePrestador = await _context.ReportesPrestadores
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.ReportePrestadorId == id);
            if (reportePrestador == null)
            {
                return NotFound();
            }

            return View(reportePrestador);
        }

        // GET: ReportesPrestadores/Create
        public async Task<IActionResult> Create(int? id)
        {
            if(id == null && _context.Acordos == null){
                return NotFound();
            }
            var acordo = await _context.Acordos.FirstOrDefaultAsync(a => a.AcordoId == id);
            var servico = await _context.Servicos.FirstOrDefaultAsync(a => a.ServicoId == acordo.FkServico);
            ViewBag.FkServico = servico.ServicoId;
            ViewBag.FkCliente = servico.FkCliente;
            ViewBag.FkPrestador = servico.FkPrestador;
            return View();
        }

        // POST: ReportesPrestadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportePrestadorId,Motivo,FkPrestador,FkCliente,FkServico")] ReportePrestador reportePrestador)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                _context.Add(reportePrestador);
                Acordo acordo = await _context.Acordos.FirstOrDefaultAsync(a => a.FkServico == reportePrestador.FkServico);
                acordo.Servico = await _context.Servicos.FirstOrDefaultAsync(s => s.ServicoId == reportePrestador.FkServico);
                acordo.Servico.Prestador = await _context.Prestadores.FirstOrDefaultAsync(p => p.PrestadorId == reportePrestador.FkPrestador);
                acordo.Servico.Cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.ClienteId == reportePrestador.FkCliente);
                acordo.ReportarPrestador();
                _context.Update(acordo.Servico.Prestador);
                _context.Update(acordo.Servico.Cliente);
                _context.Remove(acordo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Home", "Clientes", new {id = reportePrestador.FkPrestador});
                }
            }
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", reportePrestador.FkCliente);
            return View(reportePrestador);
        }

        // GET: ReportesPrestadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReportesPrestadores == null)
            {
                return NotFound();
            }

            var reportePrestador = await _context.ReportesPrestadores.FindAsync(id);
            if (reportePrestador == null)
            {
                return NotFound();
            }
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", reportePrestador.FkCliente);
            return View(reportePrestador);
        }

        // POST: ReportesPrestadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportePrestadorId,Motivo,FkPrestador,FkCliente")] ReportePrestador reportePrestador)
        {
            if (id != reportePrestador.ReportePrestadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportePrestador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportePrestadorExists(reportePrestador.ReportePrestadorId))
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
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", reportePrestador.FkCliente);
            return View(reportePrestador);
        }

        // GET: ReportesPrestadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReportesPrestadores == null)
            {
                return NotFound();
            }

            var reportePrestador = await _context.ReportesPrestadores
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.ReportePrestadorId == id);
            if (reportePrestador == null)
            {
                return NotFound();
            }

            return View(reportePrestador);
        }

        // POST: ReportesPrestadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReportesPrestadores == null)
            {
                return Problem("Entity set 'ProjectDealContext.ReportesPrestadores'  is null.");
            }
            var reportePrestador = await _context.ReportesPrestadores.FindAsync(id);
            if (reportePrestador != null)
            {
                _context.ReportesPrestadores.Remove(reportePrestador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportePrestadorExists(int id)
        {
            return _context.ReportesPrestadores.Any(e => e.ReportePrestadorId == id);
        }
    }
}
