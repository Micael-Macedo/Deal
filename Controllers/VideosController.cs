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
    public class VideosController : Controller
    {
        private readonly ProjectDealContext _context;

        public VideosController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            var projectDealContext = _context.Video.Include(v => v.Portfolio);
            return View(await projectDealContext.ToListAsync());
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video = await _context.Video
                .Include(v => v.Portfolio)
                .FirstOrDefaultAsync(m => m.VideoId == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            ViewData["FkPortfolio"] = new SelectList(_context.Portfolios, "PortfolioId", "PortfolioId");
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoId,VideoPrestador,FkPortfolio")] Video video)
        {
            if (ModelState.IsValid)
            {
                _context.Add(video);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkPortfolio"] = new SelectList(_context.Portfolios, "PortfolioId", "PortfolioId", video.FkPortfolio);
            return View(video);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video = await _context.Video.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            ViewData["FkPortfolio"] = new SelectList(_context.Portfolios, "PortfolioId", "PortfolioId", video.FkPortfolio);
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoId,VideoPrestador,FkPortfolio")] Video video)
        {
            if (id != video.VideoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(video);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.VideoId))
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
            ViewData["FkPortfolio"] = new SelectList(_context.Portfolios, "PortfolioId", "PortfolioId", video.FkPortfolio);
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video = await _context.Video
                .Include(v => v.Portfolio)
                .FirstOrDefaultAsync(m => m.VideoId == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Video == null)
            {
                return Problem("Entity set 'ProjectDealContext.Video'  is null.");
            }
            var video = await _context.Video.FindAsync(id);
            if (video != null)
            {
                _context.Video.Remove(video);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoExists(int id)
        {
          return _context.Video.Any(e => e.VideoId == id);
        }
        public async Task<IActionResult> FindService(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }
            var prestador = await _context.Prestadores.FindAsync(id);
            List<AreasDeAtuacaoDoPrestador> listAreasDeAtuacao = _context.AreasDeAtuacaoDoPrestador.Where(A => A.FkPrestador == prestador.PrestadorId).ToList();
            List<int?> IdAreasDeAtuacao= new List<int?>();
            foreach (var item in listAreasDeAtuacao)
            {
                IdAreasDeAtuacao.Add(item.FkAreaAtuacao);
            }
            List<Servico> servicos = new List<Servico>();
            foreach(var item in IdAreasDeAtuacao){
                servicos.AddRange(_context.Servicos.Where(S => S.FkCategoria == item).ToList());
            }
            List<Servico> servicosFiltrados = servicos.Where(s => s.Status == "Solicitado").ToList();
            ViewData["Servicos"]= servicosFiltrados;

            return View(prestador);
        }
    }
}
