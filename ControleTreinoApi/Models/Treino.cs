using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTreinoApi.Models;

public class Treino
{
    public int Id {get; set;}
    [Required(ErrorMessage = "O nome do treino é obrigatório.")]
    public required string Nome {get; set;}
    public string? Observacoes {get; set;}
    [Required(ErrorMessage = "O Usuário é obrigatório.")]
    public required int UsuarioId {get; set;}
    [ForeignKey("UsuarioId")]
    public Usuario? Usuario {get; set;}
}