using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb2.Models;

public class Atividades
{
    [Key]
    public int AtividadeNrId { get; set; }
    public required int VoluntarioNrId { get; set; }
    public required int InstituicaoNrId { get; set; }
    public required int OportunidadeNrId { get; set; }
    public required DateTime AtividadeDtDataInicio { get; set; }
    public DateTime AtividadeDtDataFim { get; set; }
    public required int AtividadeNrHorasTrabalhadas { get; set; }

}
