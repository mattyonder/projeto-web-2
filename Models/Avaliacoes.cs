using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb2.Models
{
    public class Avaliacoes
    {
        [Key]
        public int AvaliacaoNrId { get; set; }
        public required int VoluntarioNrId { get; set; }
        public required int InstituicaoNrId { get; set; }
        public required int OportunidadeNrId { get; set; }
        public required int AvaliacaoNrNota { get; set; }
        public string AvaliacaoTxComentario { get; set; }
        public required DateTime AvaliacaoDtDataAvaliacao { get; set; } = DateTime.Now;
    }
}
