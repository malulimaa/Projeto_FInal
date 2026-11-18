using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTreinoApi.Models;

public class RegistroSerieExecutada
{
    public int Id {get; set;}
    public required int SessaoId {get; set;}
    [ForeignKey("SessaoId")]
    public Sessao? Sessao {get; set;}
    public required int ExercicioId {get; set;}
    [ForeignKey("ExercicioId")]
    public Exercicio? Exercicio {get; set;}
    public required int NumeroSerie {get; set;}
    public required double CargaKg {get; set;}
    public required int RepeticoesRealizadas {get; set;}
}