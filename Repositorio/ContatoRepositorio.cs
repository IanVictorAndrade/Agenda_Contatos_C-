using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio;

public class ContatoRepositorio : IContatoRepositorio
{
    private readonly DatabaseContext _bancoContext;
    
    public ContatoRepositorio(DatabaseContext bancoContext)
    {
        _bancoContext = bancoContext;
    }
    
    public List<ContatoModel> Listar()
    {
        return _bancoContext.Contato.ToList();
    }
    public ContatoModel Adicionar(ContatoModel contato)
    {
        _bancoContext.Contato.Add(contato);
        _bancoContext.SaveChanges();
        
        return contato;
    }
}