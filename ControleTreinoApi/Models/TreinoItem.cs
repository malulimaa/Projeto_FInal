using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTreinoApi.Models;

public class TreinoItem 
{
    public int Id {get; set;}
    public required int TreinoId {get; set;}
    [ForeignKey("TreinoId")]
    public Treino? Treino {get; set;}
    public required int ExercicioId {get; set;}
    [ForeignKey("ExercicioId")]
    public Exercicio? Exercicio {get; set;}
    public int Ordem {get; set;}
    [Range(1, 100, ErrorMessage = "As repetições devem estar entre 1 e 100.")]
    public int RepeticoesAlvo {get; set;}
    [Range(0.0, double.MaxValue, ErrorMessage = "A carga sugerida não pode ser negativa.")]
    public double CargaSugeridaKg  {get; set;}
}