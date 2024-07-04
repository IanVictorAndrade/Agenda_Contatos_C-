using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;
namespace MeuSiteEmMVC.Controllers;

public class ContatoController : Controller
{
    private readonly IContatoRepositorio _contatoRepositorio;
    public ContatoController(IContatoRepositorio contatoRepositorio)
    {
        _contatoRepositorio = contatoRepositorio;
    }
    public IActionResult Index()
    {
        List<ContatoModel?> contatos = _contatoRepositorio.Listar();
        
        return View(contatos);
    }
    public IActionResult Criar()
    {
        return View();
    }
    public IActionResult Editar(int id)
    {
        ContatoModel? contato = _contatoRepositorio.ObterPorId(id);
        return View(contato);
    }
    public IActionResult ApagarConfirmacao(int id)
    {
        ContatoModel? contato = _contatoRepositorio.ObterPorId(id);
        return View(contato);
    }
    
    [HttpPost] 
    public IActionResult Criar(ContatoModel? contato)
    {
        _contatoRepositorio.Adicionar(contato);
        return RedirectToAction("Index");
    }
    
    [HttpPost] 
    public IActionResult Alterar(ContatoModel contato)
    {
        _contatoRepositorio.Atualizar(contato);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Apagar(int id)
    {
        _contatoRepositorio.Remover(id);
        return RedirectToAction("Index");
    }
}