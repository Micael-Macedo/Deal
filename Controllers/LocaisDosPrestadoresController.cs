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
    public class LocaisDosPrestadoresController : Controller
    {
        private readonly ProjectDealContext _context;

        public LocaisDosPrestadoresController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: LocaisDosPrestadores
        public async Task<IActionResult> Index()
        {
            var projectDealContext = _context.LocaisDoPrestador.Include(l => l.Prestador);
            return View(await projectDealContext.ToListAsync());
        }

        // GET: LocaisDosPrestadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LocaisDoPrestador == null)
            {
                return NotFound();
            }

            var localDoPrestador = await _context.LocaisDoPrestador
                .Include(l => l.Prestador)
                .FirstOrDefaultAsync(m => m.LocalDoPrestadorId == id);
            if (localDoPrestador == null)
            {
                return NotFound();
            }

            return View(localDoPrestador);
        }

        // GET: LocaisDosPrestadores/Create
        public async Task<IActionResult> Create(int? id)
        {   
            if(id == null || _context.Prestadores == null){
                return NotFound();
            }
            var prestador = _context.Prestadores.Find(id);
            if(prestador == null){
                return NotFound();
            }
            ViewBag.Prestador = prestador;
            ViewBag.PrestadorFkLocal = prestador.PrestadorId;
            return View();
        }

        // POST: LocaisDosPrestadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocaisDoPrestadorId,PrestadorFk")] LocalDoPrestador locaisDoPrestador, List<string> Cidades)
        {
            if (ModelState.IsValid)
            {
                locaisDoPrestador.Prestador = _context.Prestadores.Find(locaisDoPrestador.PrestadorFk);
                foreach (var cidade in Cidades)
                {
                    if(cidade != null){
                        locaisDoPrestador.LocalDoPrestadorId = null;
                        locaisDoPrestador.Cidade = cidade;
                        _context.Add(locaisDoPrestador);
                        await _context.SaveChangesAsync();
                    }
                }
                return RedirectToAction("Edit", "Portfolios", new {id = locaisDoPrestador.Prestador.FkPortfolio});
            }
            return RedirectToAction("Edit", "Portfolios", new {id = locaisDoPrestador.Prestador.FkPortfolio});
        }
    //Add uma pagina para adicionar Locais de atuacao
        // GET: LocaisDosPrestadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LocaisDoPrestador == null)
            {
                return NotFound();
            }

            var localDoPrestador = await _context.LocaisDoPrestador.FindAsync(id);
            if (localDoPrestador == null)
            {
                return NotFound();
            }
            Prestador prestador = await _context.Prestadores.FindAsync(localDoPrestador.PrestadorFk);
            ViewBag.Prestador = prestador;
            return View(localDoPrestador);
        }

        // POST: LocaisDosPrestadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("LocalDoPrestadorId,Cidade,PrestadorFk")] LocalDoPrestador localDoPrestador)
        {
            if (id != localDoPrestador.LocalDoPrestadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localDoPrestador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalDoPrestadorExists(localDoPrestador.LocalDoPrestadorId))
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
            ViewData["PrestadorFk"] = new SelectList(_context.Prestadores, "PrestadorId", "PrestadorId", localDoPrestador.PrestadorFk);
            return RedirectToAction(nameof(Index));
        }

        // GET: LocaisDosPrestadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LocaisDoPrestador == null)
            {
                return NotFound();
            }

            var localDoPrestador = await _context.LocaisDoPrestador
                .Include(l => l.Prestador)
                .FirstOrDefaultAsync(m => m.LocalDoPrestadorId == id);
            if (localDoPrestador == null)
            {
                return NotFound();
            }
            Prestador prestador = await _context.Prestadores.FindAsync(localDoPrestador.PrestadorFk);
            ViewBag.Prestador = prestador;

            return View(localDoPrestador);
        }

        // POST: LocaisDosPrestadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.LocaisDoPrestador == null)
            {
                return Problem("Entity set 'ProjectDealContext.LocaisDoPrestador'  is null.");
            }
            var localDoPrestador = await _context.LocaisDoPrestador.FindAsync(id);
            if (localDoPrestador != null)
            {
                _context.LocaisDoPrestador.Remove(localDoPrestador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> MeusLocais(int? id)
        {   
            if(id == null || _context.Prestadores == null){
                return NotFound();
            }
            var prestador = _context.Prestadores.Find(id);
            if(prestador == null){
                return NotFound();
            }
            ViewBag.Prestador = prestador;
            ViewBag.PrestadorId = prestador.PrestadorId;
            var projectDealContext = _context.LocaisDoPrestador.Where(l => l.PrestadorFk == id);
            return View(await projectDealContext.ToListAsync());
        }
        public async Task<IActionResult> AdicionarLocais(int? id)
        {   
            if(id == null || _context.Prestadores == null){
                return NotFound();
            }
            var prestador = _context.Prestadores.Find(id);
            if(prestador == null){
                return NotFound();
            }

            ViewBag.Prestador = prestador;
            ViewBag.PrestadorFkLocal = prestador.PrestadorId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarLocais([Bind("LocaisDoPrestadorId,PrestadorFk")] LocalDoPrestador locaisDoPrestador, List<string> Cidades)
        {
            if (ModelState.IsValid)
            {
                locaisDoPrestador.Prestador = _context.Prestadores.Find(locaisDoPrestador.PrestadorFk);
                foreach (var cidade in Cidades)
                {
                    if(cidade != null){
                        locaisDoPrestador.LocalDoPrestadorId = null;
                        locaisDoPrestador.Cidade = cidade;
                        _context.Add(locaisDoPrestador);
                        await _context.SaveChangesAsync();
                    }
                }
                return RedirectToAction("Home", "Prestadores", new {id = locaisDoPrestador.Prestador.PrestadorId});
            }
             return RedirectToAction("Home", "Prestadores", new {id = locaisDoPrestador.Prestador.PrestadorId});
        }

        private bool LocalDoPrestadorExists(int? id)
        {
          return _context.LocaisDoPrestador.Any(e => e.LocalDoPrestadorId == id);
        }
    }
}
