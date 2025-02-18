using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb2.Models;

public class Voluntarios
{
    [Key]
    public int VoluntarioNrid { get; set; }
    public required string VolutarioNTxome { get; set; }
    public required DateOnly VoluntarioDtDataNascimento { get; set; }
    public required string VoluntarioTxCpf { get; set; }
    public required string VoluntarioTxEmail { get; set; }
    public required string VoluntarioTxTelefone { get; set; }
    public required string VoluntarioTxEndereco { get; set; }

}
