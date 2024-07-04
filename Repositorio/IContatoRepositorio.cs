using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio;

public interface IContatoRepositorio
{
    ContatoModel? Adicionar(ContatoModel? contato);
    
    List<ContatoModel?> Listar();
    
    ContatoModel Atualizar(ContatoModel contato);
    
    bool Remover(int id);
    
    ContatoModel? ObterPorId(int id);
}