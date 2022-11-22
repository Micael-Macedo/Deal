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
    public class ServicosController : Controller
    {
        private readonly ProjectDealContext _context;

        public ServicosController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: Servicos
        public async Task<IActionResult> Index()
        {
            var projectDealContext = _context.Servicos.Include(s => s.Categoria).Include(s => s.Cliente);
            return View(await projectDealContext.ToListAsync());
        }

        // GET: Servicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos
                .Include(s => s.Categoria)
                .Include(s => s.Cliente)
                .FirstOrDefaultAsync(m => m.ServicoId == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // GET: Servicos/Create
        public IActionResult Create(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }
            int ClienteId = _context.Clientes.Where(c => c.ClienteId == id).FirstOrDefault().ClienteId;
            Servico servico = new Servico() { FkCliente = ClienteId };

            ViewData["FkCategoria"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "Atuacao");
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            return View(servico);
        }

        // POST: Servicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicoId,FkCliente,Nome,Descricao,Endereco,Estado,Cidade,Numero,Cep,FkCategoria,Status,Latitude,Longitude")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                servico.Status = "Solicitado";
                _context.Add(servico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCategoria"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "AreaAtuacaoId", servico.FkCategoria);
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", servico.FkCliente);
            return View(servico);
        }

        // GET: Servicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }
            ViewData["FkCategoria"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "AreaAtuacaoId", servico.FkCategoria);
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", servico.FkCliente);
            return View(servico);
        }

        // POST: Servicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicoId,FkCliente,Nome,Descricao,Endereco,Estado,Cidade,Numero,Cep,FkCategoria,Status,Latitude,Longitude")] Servico servico)
        {
            if (id != servico.ServicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.ServicoId))
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
            ViewData["FkCategoria"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "AreaAtuacaoId", servico.FkCategoria);
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", servico.FkCliente);
            return View(servico);
        }

        // GET: Servicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos
                .Include(s => s.Categoria)
                .Include(s => s.Cliente)
                .FirstOrDefaultAsync(m => m.ServicoId == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }
        // GET: Cliente/Delete/5
        public async Task<IActionResult> ClienteCancelaServico(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos
                .Include(s => s.Categoria)
                .Include(s => s.Cliente)
                .FirstOrDefaultAsync(m => m.ServicoId == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }
        // GET: Servicos/Delete/5
        public async Task<IActionResult> PrestadorCancelaServico(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos
                .Include(s => s.Categoria)
                .Include(s => s.Cliente)
                .FirstOrDefaultAsync(m => m.ServicoId == id);
            if (servico == null)
            {
                return NotFound();
            }
            ViewData["FkCategoria"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "Atuacao");
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            return View(servico);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servicos == null)
            {
                return Problem("Entity set 'ProjectDealContext.Servicos'  is null.");
            }
            var servico = await _context.Servicos.FindAsync(id);
            if (servico != null)
            {
                _context.Servicos.Remove(servico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClienteCancelarServico(int id)
        {
            if (_context.Servicos == null)
            {
                return Problem("Entity set 'ProjectDealContext.Servicos'  is null.");
            }
            var servico = await _context.Servicos.FindAsync(id);
            if (servico != null)
            {
                _context.Servicos.Remove(servico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // POST: Servicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrestadorCancelaServico(int id, [Bind("ServicoId,FkCliente,Nome,Descricao,Endereco,Estado,Cidade,Numero,Cep,FkCategoria,Status,Latitude,Longitude")] Servico servico)
        {
            if (id != servico.ServicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    servico.Status = "PrestadorCancelouServico";
                    servico.FkPrestador = null;
                    _context.Update(servico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.ServicoId))
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
            ViewData["FkCategoria"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "AreaAtuacaoId", servico.FkCategoria);
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", servico.FkCliente);
            return View(servico);
        }
        public async Task<IActionResult> AddPrestador(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }
            var servico = await _context.Servicos.FindAsync(id);
            List<AreasDeAtuacaoDoPrestador> listPrestadoresDisponiveis = _context.AreasDeAtuacaoDoPrestador.Where(A => A.FkAreaAtuacao == servico.FkCategoria).ToList();
            List<int?> IdPrestadores = new List<int?>();
            foreach (var item in listPrestadoresDisponiveis)
            {
                IdPrestadores.Add(item.FkPrestador);
            }
            List<Prestador> prestadoresFiltrados = new List<Prestador>();
            foreach (var item in IdPrestadores)
            {
                prestadoresFiltrados.Add(_context.Prestadores.Find(item));
            }
            if (servico == null)
            {
                return NotFound();
            }
            ViewData["Prestadores"] = prestadoresFiltrados;
            ViewData["FkCategoria"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "AreaAtuacaoId", servico.FkCategoria);
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", servico.FkCliente);

            return View(servico);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPrestador(int? servicoId, int? prestadorId)
        {

            if (ModelState.IsValid)
            {
                Servico servico = _context.Servicos.Find(servicoId);
                try
                {
                    servico.FkPrestador = prestadorId;
                    servico.Status = "Convite enviado";
                    _context.Update(servico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.ServicoId))
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
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> ServicosPendentes(int? id)
        {
            var projectDealContext = _context.Servicos.Where(S => S.FkPrestador == id && S.Status == "Convite Enviado").Include(s => s.Categoria).Include(s => s.Cliente);
            return View(await projectDealContext.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ServicosPendentes(int? prestadorId, int? servicoId, string escolha)
        {
            Servico servico = _context.Servicos.Find(servicoId);
            if (ModelState.IsValid)
            {
                try
                {

                    if (escolha == "Aceitar")
                    {
                        Prestador prestador = _context.Prestadores.Find(servico.FkPrestador);
                        Cliente cliente = _context.Clientes.Find(servico.FkCliente);
                        Acordo acordo = new Acordo();
                        acordo.FkServico = servicoId;
                        _context.Acordos.Add(acordo);
                        await _context.SaveChangesAsync();
                        cliente.QtdAcordoRealizados = _context.Acordos.Where(A => A.Servico.FkCliente == cliente.ClienteId).Count();
                        prestador.QtdServicoRealizados = _context.Acordos.Where(A => A.Servico.FkPrestador == prestador.PrestadorId).Count();
                        _context.Prestadores.Update(prestador);
                        await _context.SaveChangesAsync();
                        _context.Clientes.Update(cliente);
                        await _context.SaveChangesAsync();
                        servico.Status = "Acordo Feito";
                    }
                    if (escolha == "Recusar")
                    {
                        servico.FkPrestador = null;
                        servico.Status = "Servico Recusado";
                    }
                    _context.Servicos.Update(servico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.ServicoId))
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
            return RedirectToAction(nameof(Index));
        }

        private bool ServicoExists(int id)
        {
            return _context.Servicos.Any(e => e.ServicoId == id);
        }
    }
}


