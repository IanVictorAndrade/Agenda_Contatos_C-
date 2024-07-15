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
        try
        {
            if (!ModelState.IsValid) return View(contato);
            _contatoRepositorio.Adicionar(contato);
            TempData["MensagemSucesso"] = "Contato adicionado com sucesso!";
            return RedirectToAction("Index");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            TempData["MensagemErro"] = $"Erro ao adicionar contato! detalhes: {e.Message}";
            return RedirectToAction("Index");
        }
    }
    
    [HttpPost] 
    public IActionResult Alterar(ContatoModel contato)
    {
        try
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");
            _contatoRepositorio.Atualizar(contato);
            TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
            return RedirectToAction("Index");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            TempData["MensagemErro"] = $"Erro ao alterar contato! detalhes: {e.Message}";
            return RedirectToAction("Index");
        }
    }
    
    [HttpGet]
    public IActionResult Apagar(int id)
    {
        try
        {
            bool apagado = _contatoRepositorio.Remover(id);
            if (!apagado) TempData["MensagemErro"] = "Não foi possível remover o contato!";
            
            TempData["MensagemSucesso"] = "Contato removido com sucesso!";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            TempData["MensagemErro"] = $"Erro ao remover contato! detalhes: {e.Message}";
            return RedirectToAction("Index");
        }
    }
}