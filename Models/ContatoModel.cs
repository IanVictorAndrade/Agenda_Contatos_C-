using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models;

public class ContatoModel {
    
    public int Id { get; set; }
    [Required(ErrorMessage = "Digite o nome do contato")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Digite o email do contato")]
    [EmailAddress(ErrorMessage = "Digite um email válido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Digite o telefone do contato")]
    [Phone(ErrorMessage = "Digite um telefone válido")]
    public string Telefone { get; set; }
}