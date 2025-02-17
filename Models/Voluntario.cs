using System;

namespace ProjetoWeb2.Models;

public class Voluntarios
{
    public int voluntarioId { get; set; }
    public required String voluntarioCpf { get; set; }
    public required String volutarioNome { get; set; }
    public DateOnly voluntarioDataNascimento { get; set; }
    public required String voluntarioEmail { get; set; }
    public required String voluntarioTelefone { get; set; }
    public required String voluntarioEndereco { get; set; }

}
