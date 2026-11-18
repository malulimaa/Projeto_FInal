using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTreinoApi.Models;

public class Sessao
{
    public int Id {get; set;}
    public required int UsuarioId {get; set;}
    [ForeignKey("UsuarioId")]
    public Usuario? Usuario {get; set;}

    public int? TreinoId {get; set;}
    [ForeignKey ("TreinoId")]
    public Treino? Treino {get; set;}

    public DateTime DataHora {get; set;}
}