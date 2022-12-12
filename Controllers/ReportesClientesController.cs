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
    public class ReportesClientesController : Controller
    {
        private readonly ProjectDealContext _context;

        public ReportesClientesController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: ReportesClientes
        public async Task<IActionResult> Index()
        {
            var projectDealContext = _context.ReportesClientes.Include(r => r.Cliente).Include(r => r.Prestador);
            return View(await projectDealContext.ToListAsync());
        }

        // GET: ReportesClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReportesClientes == null)
            {
                return NotFound();
            }

            var reporteCliente = await _context.ReportesClientes
                .Include(r => r.Cliente)
                .Include(r => r.Prestador)
                .FirstOrDefaultAsync(m => m.ReporteClienteId == id);
            if (reporteCliente == null)
            {
                return NotFound();
            }

            return View(reporteCliente);
        }

        // GET: ReportesClientes/Create
        public async Task<IActionResult> Create(int? id)
        {
            if(id == null && _context.Acordos == null){
                return NotFound();
            }
            var acordo = await _context.Acordos.FirstOrDefaultAsync(a => a.AcordoId == id);
            var servico = await _context.Servicos.FirstOrDefaultAsync(a => a.ServicoId == acordo.FkServico);
            servico.Prestador = await _context.Prestadores.FirstOrDefaultAsync(p => p.PrestadorId == servico.FkPrestador);
            ViewBag.Prestador = servico.Prestador;
            ViewBag.FkServico = servico.ServicoId;
            ViewBag.FkCliente = servico.FkCliente;
            ViewBag.FkPrestador = servico.FkPrestador;
            return View();
        }

        // POST: ReportesClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReporteClienteId,Motivo,FkCliente,FkPrestador,FkServico")] ReporteCliente reporteCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporteCliente);
                Acordo acordo = await _context.Acordos.FirstOrDefaultAsync(a => a.FkServico == reporteCliente.FkServico);
                acordo.Servico = await _context.Servicos.FirstOrDefaultAsync(s => s.ServicoId == reporteCliente.FkServico);
                acordo.Servico.Prestador = await _context.Prestadores.FirstOrDefaultAsync(p => p.PrestadorId == reporteCliente.FkPrestador);
                acordo.Servico.Cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.ClienteId == reporteCliente.FkCliente);
                acordo.ReportarCliente();
                _context.Update(acordo.Servico);
                _context.Update(acordo.Servico.Prestador);
                _context.Update(acordo.Servico.Cliente);
                _context.Remove(acordo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Home", "Prestadores", new {id = reporteCliente.FkPrestador});

            }
            return View(reporteCliente);
        }

        // GET: ReportesClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReportesClientes == null)
            {
                return NotFound();
            }

            var reporteCliente = await _context.ReportesClientes.FindAsync(id);
            if (reporteCliente == null)
            {
                return NotFound();
            }
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", reporteCliente.FkCliente);
            ViewData["FkPrestador"] = new SelectList(_context.Prestadores, "PrestadorId", "PrestadorId", reporteCliente.FkPrestador);
            return View(reporteCliente);
        }

        // POST: ReportesClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReporteClienteId,Motivo,FkCliente,FkPrestador")] ReporteCliente reporteCliente)
        {
            if (id != reporteCliente.ReporteClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporteCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteClienteExists(reporteCliente.ReporteClienteId))
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
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", reporteCliente.FkCliente);
            ViewData["FkPrestador"] = new SelectList(_context.Prestadores, "PrestadorId", "PrestadorId", reporteCliente.FkPrestador);
            return View(reporteCliente);
        }

        // GET: ReportesClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReportesClientes == null)
            {
                return NotFound();
            }

            var reporteCliente = await _context.ReportesClientes
                .Include(r => r.Cliente)
                .Include(r => r.Prestador)
                .FirstOrDefaultAsync(m => m.ReporteClienteId == id);
            if (reporteCliente == null)
            {
                return NotFound();
            }

            return View(reporteCliente);
        }

        // POST: ReportesClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReportesClientes == null)
            {
                return Problem("Entity set 'ProjectDealContext.ReportesClientes'  is null.");
            }
            var reporteCliente = await _context.ReportesClientes.FindAsync(id);
            if (reporteCliente != null)
            {
                _context.ReportesClientes.Remove(reporteCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteClienteExists(int id)
        {
            return _context.ReportesClientes.Any(e => e.ReporteClienteId == id);
        }
    }
}
