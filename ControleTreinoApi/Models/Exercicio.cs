using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTreinoApi.Models;

public class Exercicio
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do exercício é obrigatório.")]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "O nome do exercício deve ter entre 2 a 60 caracteres.")]
    public required string Nome { get; set; }
    public required string? Descricao { get; set; }
    [Required(ErrorMessage = "O grupo muscular é obrigatório.")]
    [RegularExpression( "^(Peito|Costas|Pernas|Ombros|Braços|Abdômen|Outro)$",
    ErrorMessage = "Use: Peito, Costas, Pernas, Ombros, Braços, Abdômen ou Outro.")]
    public required string GrupoMuscular { get; set; }
    [Required(ErrorMessage = "O Usuário é obrigatório.")]
    public required int UsuarioId { get; set; }
    [ForeignKey("UsuarioId")]
    public Usuario? Usuario { get; set; }
}