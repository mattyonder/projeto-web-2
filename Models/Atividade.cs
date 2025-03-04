using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb2.Models;

public class Atividade
{
    public int Id { get; set; }
    public required string Titulo { get; set; }
    public string? Descricao { get; set; }

    [DataType(DataType.Date)]
    public required DateTime DataInicio { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DataFim { get; set; }
    public required int InstituicaoId { get; set; }
    public required List<int> HabilidadeIdList { get; set; }
}

