using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb2.Models
{
    public class Habilidades
    {
        [Key]
        public int HabilidadeNrId { get; set; }
        public required string HabilidadeTxDescricao { get; set; }
    }
}
