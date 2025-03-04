using System;

namespace ProjetoWeb2.Models;

public class VoluntarioHabilidade
{
    public int Id { get; set; }
    public required int VoluntarioId { get; set; }
    public required int HabilidadeId { get; set; }
}
