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
            var projectDealContext = _context.Servicos.Include(s => s.Categoria).Include(s => s.Cliente).Include(s => s.Prestador);
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
                 return RedirectToAction("MeusServicos", "Servicos", new { id = servico.FkCliente });
            }
            ViewData["FkCategoria"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "AreaAtuacaoId", servico.FkCategoria);
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", servico.FkCliente);
            return RedirectToAction("MeusServicos", "Servicos", new { id = servico.FkCliente });
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
            ViewData["FkCategoria"] = new SelectList(_context.AreaAtuacao, "AreaAtuacaoId", "Atuacao", servico.FkCategoria);
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "ClienteId", "Nome", servico.FkCliente);
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
            return RedirectToAction("MeusServicos", "Servicos", new { id = servico.FkCliente });
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
            Servico servico = await _context.Servicos.FindAsync(id);
            int? clienteId = servico.FkCliente;
            if (servico != null)
            {
                _context.Servicos.Remove(servico);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Home","Clientes", new {id = clienteId});
        }
        // POST: Servicos/Delete/5
        [HttpPost]
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
            return RedirectToAction("MeusServicos", "Servicos", new { id = servico.FkCliente });
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
            return RedirectToAction("Home", "Prestador", new { id = servico.Prestador });
        }
        public async Task<IActionResult> AddPrestador(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }
            var servico = await _context.Servicos.FindAsync(id);
            servico.Categoria = _context.AreaAtuacao.Find(servico.FkCategoria);
            List<AreasDeAtuacaoDoPrestador> listPrestadoresDisponiveis = _context.AreasDeAtuacaoDoPrestador.Where(A => A.FkAreaAtuacao == servico.FkCategoria).ToList();
            List<Prestador> prestadoresServico = new List<Prestador>();
            foreach (var prestadoresDisponiveis in listPrestadoresDisponiveis)
            {
                prestadoresServico.Add(_context.Prestadores.Find(prestadoresDisponiveis.FkPrestador));
            }
            List<Prestador> prestadoresFiltrados = new List<Prestador>();
            if(servico.Categoria.isOnline == false){

                List<LocalDoPrestador> LocaisDosPrestadores= new List<LocalDoPrestador>();
                foreach(var prestador in prestadoresServico){
                    LocaisDosPrestadores.AddRange(_context.LocaisDoPrestador.Where(l => l.PrestadorFk == prestador.PrestadorId && l.Cidade == servico.Cidade).ToList());
                }

                foreach (var local in LocaisDosPrestadores)
                {
                    prestadoresFiltrados.Add(_context.Prestadores.Find(local.PrestadorFk));
                }
            }else{
                prestadoresFiltrados = prestadoresServico;
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
                return RedirectToAction("MeusServicos", "Servicos", new { id = servico.FkCliente });
            }
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> ServicosPendentes(int? id)
        {
            ViewBag.prestadorIdServicosPendentes = id;
            List<LocalDoPrestador> locaisDoPestador = _context.LocaisDoPrestador.Where(l => l.PrestadorFk == id).ToList();
            List<Servico> filtroServicosLocalizacao = new List<Servico>();
            foreach (var localDoPrestador in locaisDoPestador)
            {
                filtroServicosLocalizacao.AddRange(_context.Servicos.Where(s => s.Cidade == localDoPrestador.Cidade));
            }
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
                        servico.AcordoAceito();
                        Acordo acordo = new Acordo();
                        acordo.FkServico = servicoId;
                        _context.Acordos.Add(acordo);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("AcordoPrestador", "Acordo", new { id = acordo.AcordoId });
                    }
                    if (escolha == "Recusar")
                    {
                        servico.PrestadorRecusaServico();
                        return RedirectToAction("Home", "Prestadores", new { id = prestadorId });

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
        public async Task<IActionResult> ConfirmarAcordo(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos
                .Include(s => s.Categoria)
                .Include(s => s.Cliente)
                .Include(s => s.Prestador)
                .FirstOrDefaultAsync(m => m.ServicoId == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarAcordo(int? servicoId, string escolha)
        {
            Servico servico = _context.Servicos.Find(servicoId);
            if (ModelState.IsValid)
            {
                try
                {
                    if (escolha == "Aceitar")
                    {
                        servico.AcordoAceito();
                        Acordo acordo = new Acordo();
                        acordo.FkServico = servicoId;
                        _context.Acordos.Add(acordo);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("AcordoCliente", "Acordo", new { id = acordo.AcordoId });
                    }
                    if (escolha == "Recusar")
                    {
                        servico.ClienteRecusaServico();
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
        public async Task<IActionResult> MeusServicos(int? id)
        {
            ViewData["IdCliente"] = id;
            var projectDealContext = _context.Servicos.Where(s => s.FkCliente == id).Include(s => s.Categoria).Include(s => s.Cliente).Include(s => s.Prestador);
            return View(await projectDealContext.ToListAsync());
        }
        private bool ServicoExists(int id)
        {
            return _context.Servicos.Any(e => e.ServicoId == id);
        }
    }
}


