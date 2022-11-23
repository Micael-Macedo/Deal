using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Deal.Models;

namespace Deal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
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
        if(direcionamento == true){
            return RedirectToAction("Home","Prestadores", email, senha);
        }if(direcionamento == false){
            return RedirectToAction("Home","Clientes", email, senha);
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
