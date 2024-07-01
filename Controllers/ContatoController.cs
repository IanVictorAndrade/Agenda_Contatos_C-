using MeuSiteEmMVC.Models;
using Microsoft.AspNetCore.Mvc;
namespace MeuSiteEmMVC.Controllers;

public class ContatoController : Controller
{
    public IActionResult Index()
    {
        ContatoModel contato = new ContatoModel();
        contato.Nome = "Ian Victor";
        contato.Email = "ian@gmail.com";
        contato.Telefone = "999999999";
        return View(contato);
    }
}