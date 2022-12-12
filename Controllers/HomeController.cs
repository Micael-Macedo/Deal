using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Deal.Models;

namespace Deal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProjectDealContext _context;
    public HomeController(ILogger<HomeController> logger, ProjectDealContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index(int? id, string? user)
    {
        ViewBag.UserId = id;
        if(user == "Prestador"){
            Prestador prestador = await _context.Prestadores.FindAsync(id);
            if(prestador != null){
                ViewBag.Prestador = prestador;
            }
            
        }
        if(user == "Cliente"){
            Cliente cliente = await _context.Clientes.FindAsync(id);
            if(cliente != null){
                ViewBag.Cliente = cliente;
            }
            
        }
        return View();
    }
    public IActionResult login()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult login(string email, string senha, bool direcionamento)
    {
        if (direcionamento == true)
        {
            return RedirectToAction("Home", "Prestadores", email, senha);
        }
        if (direcionamento == false)
        {
            return RedirectToAction("Home", "Clientes", email, senha);
        }
        return View();
    }


    public IActionResult criarConta()
    {
        return View();
    }
    public IActionResult direcionamento()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
