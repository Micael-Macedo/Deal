using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Deal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Deal.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ProjectDealContext _context;

        public UsuariosController(ProjectDealContext context)
        {
            _context = context;
        }
        [Route("[controller]")]

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Entrar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (usuario.Perfil.ToString()== "Prestador")
                    {
                        Prestador prestador = await _context.Prestadores.FirstOrDefaultAsync(p => p.Email == usuario.Email && p.Senha == usuario.Senha);
                        if (prestador != null)
                        {
                            return RedirectToAction("Home", "Prestadores", new { id = prestador.PrestadorId });
                        }
                    }
                    if (usuario.Perfil.ToString()== "Cliente")
                    {
                        Cliente cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == usuario.Email && c.Senha == usuario.Senha);
                        if (cliente != null)
                        {
                            return RedirectToAction("Home", "Clientes", new { id = cliente.ClienteId });
                        }
                    }
                }

                return View("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Login não pode ser realizado: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}