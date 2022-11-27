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
    public class PrestadoresController : Controller
    {
        private readonly ProjectDealContext _context;

        public PrestadoresController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: Prestadores
        public async Task<IActionResult> Index()
        {
            List<Prestador> prestadores = await _context.Prestadores.ToListAsync();
            foreach (var prestador in prestadores)
            {
                List<NotaPrestador> notasDoPrestador = await _context.NotaPrestadores.Where(n => n.FkPrestador == prestador.PrestadorId).ToListAsync();
                if(notasDoPrestador.Count != 0){
                    prestador.NotasDoPrestador = notasDoPrestador;
                }
                prestador.Pontuacao = prestador.MediaNota();
                _context.Prestadores.Update(prestador);
                await _context.SaveChangesAsync();
            }
            var projectDealContext = _context.Prestadores.Include(p => p.Portfolio);
            return View(await projectDealContext.ToListAsync());
        }

        // GET: Prestadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prestadores == null)
            {
                return NotFound();
            }
            List<AreasDeAtuacaoDoPrestador> listAreasDeAtuacaoDoPrestador = await _context.AreasDeAtuacaoDoPrestador.Where(A => A.FkPrestador == id).ToListAsync();
            List<AreaAtuacao> AreasDeAtuacaoDoPrestador = new List<AreaAtuacao>();
            foreach (var areaAtuacao in listAreasDeAtuacaoDoPrestador)
            {
                AreasDeAtuacaoDoPrestador.Add(_context.AreaAtuacao.Find(areaAtuacao.FkAreaAtuacao));
            }
            var prestador = await _context.Prestadores
                .Include(p => p.Portfolio)
                .FirstOrDefaultAsync(m => m.PrestadorId == id);
            prestador.AreasAtuacao = AreasDeAtuacaoDoPrestador;
            if (prestador == null)
            {
                return NotFound();
            }
            ViewBag.areasAtuacao = AreasDeAtuacaoDoPrestador;
            return View(prestador);
        }

        // GET: Prestadores/Create
        public IActionResult Create()
        {
            ViewData["AreaAtuacaoId"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "Atuacao");
            ViewData["FkPortfolio"] = new SelectList(_context.Portfolios, "PortfolioId", "PortfolioId");
            return View();
        }

        // POST: Prestadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrestadorId,FotoPrestador,FkPortfolio,Nome,Cpf,Idade,Endereco,Cep,Telefone,Senha,Email,QtdServicoRealizados")] Prestador prestador, List<int> areasAtuacao)

        {
            if (ModelState.IsValid)
            {
                if(areasAtuacao == null){
                    return NotFound();
                }
                _context.Add(prestador);
                await _context.SaveChangesAsync();
                foreach (int areasAtuacaoId in areasAtuacao)
                {
                    AreasDeAtuacaoDoPrestador areasDeAtuacaoDosPrestadores = new AreasDeAtuacaoDoPrestador();
                    areasDeAtuacaoDosPrestadores.FkPrestador = prestador.PrestadorId;
                    areasDeAtuacaoDosPrestadores.FkAreaAtuacao = areasAtuacaoId;
                    _context.AreasDeAtuacaoDoPrestador.Add(areasDeAtuacaoDosPrestadores);
                }
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            ViewData["FkPortfolio"] = new SelectList(_context.Portfolios, "PortfolioId", "PortfolioId", prestador.FkPortfolio);
            return View(prestador);
        }

        // GET: Prestadores/Edit/5
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

            ViewData["FkPortfolio"] = new SelectList(_context.Portfolios, "PortfolioId", "PortfolioId", prestador.FkPortfolio);
            return View(prestador);
        }

        // POST: Prestadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrestadorId,FotoPrestador,FkPortfolio,Nome,Cpf,Idade,Endereco,Cep,Telefone,Senha,Email,QtdServicoRealizados")] Prestador prestador, List<int> areasAtuacao)
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
                    foreach (int areasAtuacaoId in areasAtuacao)
                    {
                        AreasDeAtuacaoDoPrestador areasDeAtuacaoDosPrestadores = new AreasDeAtuacaoDoPrestador();
                        areasDeAtuacaoDosPrestadores.FkPrestador = prestador.PrestadorId;
                        areasDeAtuacaoDosPrestadores.FkAreaAtuacao = areasAtuacaoId;
                        _context.AreasDeAtuacaoDoPrestador.Update(areasDeAtuacaoDosPrestadores);
                    }
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
            ViewData["AreaAtuacaoId"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "Atuacao");
            ViewData["FkPortfolio"] = new SelectList(_context.Portfolios, "PortfolioId", "PortfolioId", prestador.FkPortfolio);
            return View(prestador);
        }

        // GET: Prestadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prestadores == null)
            {
                return NotFound();
            }

            var prestador = await _context.Prestadores
                .Include(p => p.Portfolio)
                .FirstOrDefaultAsync(m => m.PrestadorId == id);
            if (prestador == null)
            {
                return NotFound();
            }

            return View(prestador);
        }


        // POST: Prestadores/Delete/5
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

        public async Task<IActionResult> FindService(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }
            var prestador = await _context.Prestadores.FindAsync(id);
            List<AreasDeAtuacaoDoPrestador> listAreasDeAtuacao = _context.AreasDeAtuacaoDoPrestador.Where(A => A.FkPrestador == prestador.PrestadorId).ToList();
            List<AreaAtuacao> AreasDeAtuacao = new List<AreaAtuacao>();
            foreach (var item in listAreasDeAtuacao)
            {
                AreasDeAtuacao.Add(_context.AreaAtuacao.Find(item.FkAreaAtuacao));
            }
            List<Servico> servicos = new List<Servico>();
            foreach (var item in AreasDeAtuacao)
            {
                servicos.AddRange(_context.Servicos.Where(S => S.FkCategoria == item.AreaAtuacaoId).ToList());
            }
            List<Servico> servicosFiltrados = servicos.Where(s => s.Status == "Solicitado").ToList();
            ViewData["Servicos"] = servicosFiltrados;
            return View(prestador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FindService(int? servicoId, int? prestadorId)
        {
            if (servicoId == null || _context.Servicos == null)
            {
                return NotFound();
            }
            Prestador prestador = await _context.Prestadores.FindAsync(prestadorId);
            try
            {
                Servico servico = _context.Servicos.Find(servicoId);
                servico.FkPrestador = prestadorId;
                servico.Status = "Prestador tem interesse";
                _context.Servicos.Update(servico);
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
        private bool PrestadorExists(int id)
        {
            return _context.Prestadores.Any(e => e.PrestadorId == id);
        }
    }
}

