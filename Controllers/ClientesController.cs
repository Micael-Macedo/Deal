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
    public class ClientesController : Controller
    {
        private readonly ProjectDealContext _context;

        public ClientesController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            List<Cliente> clientes = await _context.Clientes.ToListAsync();
            foreach (var cliente in clientes)
            {
                List<NotaCliente> notasDoCliente = await _context.NotaClientes.Where(n => n.FkCliente == cliente.ClienteId).ToListAsync();
                if(notasDoCliente.Count != 0){
                    cliente.NotasDoCliente = notasDoCliente;
                }
                cliente.Pontuacao = cliente.MediaNota();
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
            }
            var projectDealContext = _context.Clientes;
            return View(await projectDealContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            
            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,FotoUsuario,Nome,Cpf,Idade,Endereco,Cep,Telefone,Senha,Email,QtdAcordoRealizados")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Home","Clientes", new {id = cliente.ClienteId} );
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewBag.Cliente = cliente;
            return View(cliente);
        }
        public async Task<IActionResult> Home(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewBag.Cliente = cliente;
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,FotoUsuario,Nome,Cpf,Idade,Endereco,Cep,Telefone,Senha,Email,QtdAcordoRealizados")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Home","Clientes", new {id = cliente.ClienteId} );
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewBag.Cliente = cliente;

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'ProjectDealContext.Clientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }
    }
}
