using System;

namespace ProjetoWeb2.Models;

public class Instituicao
{
    public int Id { get; set; }
    public required string Cnjp { get; set; }
    public required string Nome { get; set; }
    public required string AreaAtuacao { get; set; }
    public required string Email { get; set; }
    public required string Contato { get; set; }
    public required string Endereco { get; set; }
}
