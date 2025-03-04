using System;

namespace ProjetoWeb2.Models;

public class Voluntario
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required DateTime DataNascimento { get; set; }
    public required string Telefone { get; set; }
    public required string Endereco { get; set; }

}
