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
            var projectDealContext = _context.Prestadores.Include(p => p.Portfolio).Include(p => p.NotasDoPrestador);
            return View(await projectDealContext.ToListAsync());
        }

        // GET: Prestadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prestadores == null)
            {
                return NotFound();
            }
            List<AreasDeAtuacaoDoPrestador> listAreasDeAtuacaoDoPrestador = _context.AreasDeAtuacaoDoPrestador.Where(A => A.FkPrestador == id).ToList();
            List<AreaAtuacao> AreasDeAtuacaoDoPrestador = new List<AreaAtuacao>();
            foreach (var item in listAreasDeAtuacaoDoPrestador)
            {
                AreasDeAtuacaoDoPrestador.Add(_context.AreaAtuacao.Find(item.FkAreaAtuacao));
                System.Console.WriteLine(AreasDeAtuacaoDoPrestador);
            }
            var prestador = await _context.Prestadores
                .Include(p => p.Portfolio)
                .FirstOrDefaultAsync(m => m.PrestadorId == id);
            prestador.AreasAtuacao = AreasDeAtuacaoDoPrestador;
            if (prestador == null)
            {
                return NotFound();
            }

            return View(prestador);
        }

        // GET: Prestadores/Create
        public IActionResult Create()
        {
            List<AreaAtuacao> listacheckAreaAtuacao = new List<AreaAtuacao>();
            Random rand = new Random();

            for (int i = 0; i < _context.AreaAtuacao.Count(); i++)
            {
                AreaAtuacao listaAreaAtuacao = new AreaAtuacao
                {
                    AreaAtuacaoId = i,
                    Atuacao = "CHECK" + i
                };

                listacheckAreaAtuacao.Add(listaAreaAtuacao);
            }
            ViewData["AreaAtuacao"] = listacheckAreaAtuacao;

            ViewData["FkPortfolio"] = new SelectList(_context.Portfolios, "PortfolioId", "PortfolioId");
            ViewData["AreaAtuacao"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "Atuacao");
            return View();
        }

        // POST: Prestadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrestadorId,FotoPrestador,FkPortfolio,Nome,Cpf,Idade,Endereco,Cep,Telefone,Senha,Email,QtdServicoRealizados")] Prestador prestador, List<AreaAtuacao> AreasAtuacaoDoPrestador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestador);
                await _context.SaveChangesAsync();
                prestador = _context.Prestadores.Find(prestador);
                foreach (var atuacao in AreasAtuacaoDoPrestador)
                {
                    AreasDeAtuacaoDoPrestador RelacionarAreasDeAtuacaoComPrestador = new AreasDeAtuacaoDoPrestador();
                    RelacionarAreasDeAtuacaoComPrestador.FkPrestador = prestador.PrestadorId;
                    RelacionarAreasDeAtuacaoComPrestador.FkAreaAtuacao = atuacao.AreaAtuacaoId;
                    _context.AreasDeAtuacaoDoPrestador.Add(RelacionarAreasDeAtuacaoComPrestador);
                    await _context.SaveChangesAsync();
                }
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
        public async Task<IActionResult> Edit(int id, [Bind("PrestadorId,FotoPrestador,FkPortfolio,Nome,Cpf,Idade,Endereco,Cep,Telefone,Senha,Email,QtdServicoRealizados")] Prestador prestador)
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

