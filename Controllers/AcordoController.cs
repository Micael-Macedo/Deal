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
    public class AcordoController : Controller
    {
        private readonly ProjectDealContext _context;

        public AcordoController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: Acordo
        public async Task<IActionResult> Index()
        {
            return _context.Acordos != null ?
                        View(await _context.Acordos.ToListAsync()) :
                        Problem("Entity set 'ProjectDealContext.Acordos'  is null.");
        }
        public async Task<IActionResult> ClienteAcordos(int? id)
        {
            List<Acordo> acordos = await _context.Acordos.Where(a => a.Servico.FkCliente == id).ToListAsync();
            return _context.Acordos != null ?
                        View(acordos) :
                        Problem("Entity set 'ProjectDealContext.Acordos'  is null.");
        }
        public async Task<IActionResult> PrestadorAcordos(int? id)
        {
            Prestador prestador = await _context.Prestadores.FindAsync(id);
            ViewBag.Prestador = prestador;
            List<Acordo> acordos = await _context.Acordos.Where(a => a.Servico.FkPrestador == id).ToListAsync();
            return _context.Acordos != null ?
                        View(acordos) :
                        Problem("Entity set 'ProjectDealContext.Acordos'  is null.");
        }

        // GET: Acordo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
                .FirstOrDefaultAsync(m => m.AcordoId == id);
            if (acordo == null)
            {
                return NotFound();
            }

            return View(acordo);
        }


        // GET: Acordo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acordo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcordoId")] Acordo acordo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acordo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acordo);
        }

        // GET: Acordo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos.FindAsync(id);
            if (acordo == null)
            {
                return NotFound();
            }
            return View(acordo);
        }

        // POST: Acordo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcordoId")] Acordo acordo)
        {
            if (id != acordo.AcordoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acordo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcordoExists(acordo.AcordoId))
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
            return View(acordo);
        }

        // GET: Acordo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
                .FirstOrDefaultAsync(m => m.AcordoId == id);
            if (acordo == null)
            {
                return NotFound();
            }

            return View(acordo);
        }

        // POST: Acordo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClientCancela(int id)
        {
            if (_context.Acordos == null)
            {
                return Problem("Entity set 'ProjectDealContext.Acordos'  is null.");
            }
            var acordo = await _context.Acordos.FindAsync(id);
            acordo.Servico = _context.Servicos.Find(acordo.FkServico);

            if (acordo != null)
            {
                _context.Acordos.Remove(acordo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> HomePage(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
            .Include(m => m.Servico.Cliente)
            .Include(m => m.Servico.Cliente.NotasDoCliente)
            .Include(m => m.Servico.Prestador)
            .Include(m => m.Servico.Prestador.NotasDoPrestador)
            .Include(m => m.Servico.Categoria)
                .FirstOrDefaultAsync(m => m.AcordoId == id);

            if (acordo == null)
            {
                return NotFound();
            }
            return View(acordo);
        }
        public async Task<IActionResult> AcordoCliente(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
            .Include(m => m.Servico.Cliente)
            .Include(m => m.Servico.Prestador)
            .Include(m => m.Servico.Prestador.NotasDoPrestador)
            .Include(m => m.Servico.Categoria)
                .FirstOrDefaultAsync(m => m.AcordoId == id);

            if (acordo == null)
            {
                return NotFound();
            }
            ViewBag.Cliente = acordo.Servico.Cliente;
            return View(acordo);
        }
        public async Task<IActionResult> AcordoPrestador(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
            .Include(m => m.Servico)
            .Include(m => m.Servico.Cliente)
            .Include(m => m.Servico.Cliente.NotasDoCliente)
            .Include(m => m.Servico.Categoria)
                .FirstOrDefaultAsync(m => m.AcordoId == id);

            if (acordo == null)
            {
                return NotFound();
            }

            Prestador prestador = await _context.Prestadores.FirstOrDefaultAsync(p => p.PrestadorId == acordo.Servico.FkPrestador);
            ViewBag.Prestador = prestador;
            return View(acordo);
        }
        public async Task<IActionResult> AvaliacaoDoCliente(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
            .Include(m => m.Servico)
            .Include(m => m.Servico.Cliente)
            .Include(m => m.Servico.Prestador)
            .FirstOrDefaultAsync(m => m.AcordoId == id);
            if (acordo == null || acordo.AvaliouCliente == true)
            {
                return NotFound();
            }
            Prestador prestador = await _context.Prestadores.FirstOrDefaultAsync(p => p.PrestadorId == acordo.Servico.FkPrestador);
            ViewBag.Prestador = prestador;

            return View(acordo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AvaliacaoDoCliente(int? AcordoId, int nota)
        {
            if (_context.Acordos == null)
            {
                return NotFound();
            }
            Acordo acordo = _context.Acordos.Find(AcordoId);
            Servico servico = _context.Servicos.Find(acordo.FkServico);
            if (ModelState.IsValid)
            {
                NotaCliente notaCliente = new NotaCliente();
                notaCliente.FkCliente = servico.FkCliente;
                notaCliente.Avaliacao = nota;
                notaCliente.FkAcordo = acordo.AcordoId;
                _context.NotaClientes.Add(notaCliente);
                acordo.AvaliarCliente();
                _context.Acordos.Update(acordo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Home", "Prestadores", new { id = servico.FkPrestador });
            }
            return View(acordo);
        }
        public async Task<IActionResult> AvaliacaoDoPrestador(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
            .Include(m => m.Servico)
            .Include(m => m.Servico.Cliente)
            .Include(m => m.Servico.Prestador)
            .FirstOrDefaultAsync(m => m.AcordoId == id);
            if (acordo == null || acordo.AvaliouPrestador == true)
            {
                return NotFound();
            }
            acordo.Servico = await _context.Servicos.FindAsync(acordo.FkServico);
            acordo.Servico.Cliente = await _context.Clientes.FindAsync(acordo.Servico.FkCliente);
            ViewBag.Cliente = acordo.Servico.Cliente;

            return View(acordo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AvaliacaoDoPrestador(int? AcordoId, int nota)
        {
            if (_context.Acordos == null)
            {
                return NotFound();
            }
            Acordo acordo = _context.Acordos.Find(AcordoId);
            Servico servico = _context.Servicos.Find(acordo.FkServico);
            if (ModelState.IsValid)
            {
                NotaPrestador notaPrestador = new NotaPrestador();
                notaPrestador.FkPrestador = servico.FkPrestador;
                notaPrestador.Avaliacao = nota;
                notaPrestador.FkAcordo = acordo.AcordoId;
                _context.NotaPrestadores.Add(notaPrestador);

                acordo.AvaliarPrestador();
                _context.Acordos.Update(acordo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Home", "Clientes", new { id = servico.FkCliente });
            }
            return View(acordo);
        }
        public async Task<IActionResult> ClienteFinalizaAcordo(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
            .Include(m => m.Servico)
            .Include(m => m.Servico.Categoria)
            .Include(m => m.Servico.Cliente)
            .Include(m => m.Servico.Prestador)
            .FirstOrDefaultAsync(m => m.AcordoId == id);
            if (acordo == null)
            {
                return NotFound();
            }
            acordo.Servico = await _context.Servicos.FindAsync(acordo.FkServico);
            acordo.Servico.Cliente = await _context.Clientes.FindAsync(acordo.Servico.FkCliente);
            ViewBag.Cliente = acordo.Servico.Cliente;
            return View(acordo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClienteFinalizaAcordo(int? acordoId, string Finalizar)
        {
            if (_context.Acordos == null)
            {
                return NotFound();
            }
            Acordo acordo = _context.Acordos.Find(acordoId);
            if (acordo == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (Finalizar == "true")
                {
                    acordo.ClienteFinalizouAcordo();
                    acordo.Servico = _context.Servicos.Find(acordo.FkServico);
                    acordo.Servico.Prestador = _context.Prestadores.Find(acordo.Servico.FkPrestador);
                    acordo.Servico.Cliente = _context.Clientes.Find(acordo.Servico.FkCliente);
                    if (acordo.VerificarSeAcordoFoiFinalizado())
                    {
                        acordo.FinalizarAcordo();
                        _context.Acordos.Update(acordo);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("AvaliacaoDoPrestador", "Acordo", new { id = acordo.AcordoId });
                    }
                    _context.Acordos.Update(acordo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Home", "Clientes", new { id = acordo.Servico.FkCliente });
                }
            }
            return View(acordo);
        }
        public async Task<IActionResult> PrestadorFinalizaAcordo(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
            .Include(m => m.Servico)
            .Include(m => m.Servico.Categoria)
            .Include(m => m.Servico.Cliente)
            .Include(m => m.Servico.Prestador)
            .FirstOrDefaultAsync(m => m.AcordoId == id);
            if (acordo == null)
            {
                return NotFound();
            }
            Prestador prestador = await _context.Prestadores.FirstOrDefaultAsync(p => p.PrestadorId == acordo.Servico.FkPrestador);
            ViewBag.Prestador = prestador;

            return View(acordo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrestadorFinalizaAcordo(int? acordoId, string Finalizar)
        {
            if (_context.Acordos == null)
            {
                return NotFound();
            }
            Acordo acordo = _context.Acordos.Find(acordoId);
            if (acordo == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (Finalizar == "true")
                {
                    acordo.PrestadorFinalizouAcordo();
                    acordo.Servico = _context.Servicos.Find(acordo.FkServico);
                    acordo.Servico.Prestador = _context.Prestadores.Find(acordo.Servico.FkPrestador);
                    acordo.Servico.Cliente = _context.Clientes.Find(acordo.Servico.FkCliente);
                    int idPrestador = acordo.Servico.Prestador.PrestadorId;
                    if (acordo.VerificarSeAcordoFoiFinalizado())
                    {

                        acordo.FinalizarAcordo();
                        _context.Acordos.Update(acordo);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("AvaliacaoDoCliente", "Acordo", new { id = acordo.AcordoId });
                    }
                    _context.Acordos.Update(acordo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Home", "Prestadores", new { id = idPrestador });
                }
            }
            return View(acordo);
        }
        public async Task<IActionResult> CancelarAcordo(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
            .Include(a => a.Servico)
            .Include(a => a.Servico.Cliente)
            .Include(a => a.Servico.Cliente.NotasDoCliente)
            .Include(a => a.Servico.Prestador)
                .FirstOrDefaultAsync(m => m.AcordoId == id);
            if (acordo == null)
            {
                return NotFound();
            }
            acordo.Servico = await _context.Servicos.FindAsync(acordo.FkServico);
            acordo.Servico.Cliente = await _context.Clientes.FindAsync(acordo.Servico.FkCliente);
            ViewBag.Cliente = acordo.Servico.Cliente;

            return View(acordo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelarAcordo(int? id, string justificativa)
        {
            Acordo acordo = await _context.Acordos.FindAsync(id);
            acordo.Servico = await _context.Servicos.FindAsync(acordo.FkServico);
            acordo.Servico.Cliente = await _context.Clientes.FindAsync(acordo.Servico.FkCliente);
            acordo.Servico.Cliente.NotasDoCliente = await _context.NotaClientes.Where(n => n.FkCliente == acordo.Servico.Cliente.ClienteId).ToListAsync();
            int clienteId = acordo.Servico.Cliente.ClienteId;
            acordo.CancelarAcordo();

            AcordoCancelado acordoCancelado = new AcordoCancelado();
            acordoCancelado.AcordoFk = acordo.AcordoId;
            acordoCancelado.Justificativa = justificativa;
            _context.AcordosCancelados.Add(acordoCancelado);
            await _context.SaveChangesAsync();

            _context.Clientes.Update(acordo.Servico.Cliente);
            _context.Servicos.Remove(acordo.Servico);
            _context.Acordos.Remove(acordo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Home", "Clientes", new { id = clienteId });
        }
        public async Task<IActionResult> EncerrarAcordo(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            var acordo = await _context.Acordos
            .Include(a => a.Servico)
            .Include(a => a.Servico.Cliente)
            .Include(a => a.Servico.Prestador)
            .Include(a => a.Servico.Prestador.NotasDoPrestador)
                .FirstOrDefaultAsync(m => m.AcordoId == id);
            if (acordo == null)
            {
                return NotFound();
            }
            Prestador prestador = await _context.Prestadores.FirstOrDefaultAsync(p => p.PrestadorId == acordo.Servico.FkPrestador);
            ViewBag.Prestador = prestador;

            return View(acordo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EncerrarAcordo(int? id, string justificativa)
        {
            Acordo acordo = await _context.Acordos.FindAsync(id);
            acordo.Servico = await _context.Servicos.FindAsync(acordo.FkServico);
            acordo.Servico.Prestador = await _context.Prestadores.FindAsync(acordo.Servico.FkPrestador);
            int prestadorId = acordo.Servico.Prestador.PrestadorId;
            acordo.Servico.Prestador.NotasDoPrestador = await _context.NotaPrestadores.Where(n => n.FkPrestador == acordo.Servico.Prestador.PrestadorId).ToListAsync();
            if (acordo.EncerrarAcordo())
            {
                _context.Prestadores.Update(acordo.Servico.Prestador);
                acordo.Servico.FkPrestador = null;
            }

            AcordoCancelado acordoCancelado = new AcordoCancelado();
            acordoCancelado.AcordoFk = acordo.AcordoId;
            acordoCancelado.Justificativa = justificativa;
            _context.Add(acordoCancelado);

            _context.Servicos.Update(acordo.Servico);
            _context.Acordos.Remove(acordo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Home", "Prestadores", new { id = prestadorId });
        }
        public async Task<IActionResult> AcordosCliente(int? id)
        {
            if (id == null || _context.Acordos == null)
            {
                return NotFound();
            }

            ViewBag.ClienteId = id;
            List<Acordo> acordos = await _context.Acordos.Where(a => a.Servico.FkCliente == id).ToListAsync();
            foreach (var acordo in acordos)
            {
                acordo.Servico = await _context.Servicos.FindAsync(acordo.FkServico);
                acordo.Servico.Categoria = await _context.AreaAtuacao.FindAsync(acordo.Servico.FkCategoria);
            }
            Cliente cliente = await _context.Clientes.FindAsync(id);
            ViewBag.Cliente = cliente;
            return View(acordos);
        }
        public async Task<IActionResult> AcordosPrestador(int? id)
        {
            ViewBag.PrestadorIdAcordo = id;
            List<Acordo> acordos = await _context.Acordos.Where(a => a.Servico.FkPrestador == id).ToListAsync();
            foreach (var acordo in acordos)
            {
                acordo.Servico = await _context.Servicos.FindAsync(acordo.FkServico);
                acordo.Servico.Categoria = await _context.AreaAtuacao.FindAsync(acordo.Servico.FkCategoria);
            }
            Prestador prestador = await _context.Prestadores.FindAsync(id);
            ViewBag.Prestador = prestador;
            return View(acordos);
        }
        private bool AcordoExists(int id)
        {
            return (_context.Acordos?.Any(e => e.AcordoId == id)).GetValueOrDefault();
        }
    }
}