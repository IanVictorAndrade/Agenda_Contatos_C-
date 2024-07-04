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

    public List<ContatoModel?> Listar()
    {
        return _bancoContext.Contato.ToList();
    }

    public ContatoModel? ObterPorId(int id)
    {
        return _bancoContext.Contato.FirstOrDefault(c => c.Id == id) ?? throw new Exception("Contato não encontrado");
    }

    public bool Remover(int id)
    {
        ContatoModel contatoDatabase = ObterPorId(id) ?? throw new Exception("Contato não encontrado");
        _bancoContext.Contato.Remove(contatoDatabase);
        _bancoContext.SaveChanges();

        return true;
    }

    public ContatoModel Atualizar(ContatoModel contato)
    {
        ContatoModel? contatoDatabase = ObterPorId(contato.Id);
        if (contatoDatabase == null) throw new Exception("Contato não encontrado");
        contatoDatabase.Nome = contato.Nome;
        contatoDatabase.Email = contato.Email;
        contatoDatabase.Telefone = contato.Telefone;
        _bancoContext.Contato.Update(contatoDatabase);
        _bancoContext.SaveChanges();

        return contato;
    }

    public ContatoModel? Adicionar(ContatoModel? contato)
    {
        _bancoContext.Contato.Add(contato);
        _bancoContext.SaveChanges();

        return contato;
    }
}