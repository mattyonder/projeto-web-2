using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb2.Models
{
    public class Oportunidades
    {
        [Key]
        public int OportunidadeNrId { get; set; }
        public required int InstituicaoNrId { get; set; }
        public required string OportunidadeTxTitulo { get; set; }
        public required string OportunidadeTxDescricao { get; set; }
        public required string OportunidadeTxLocalizacao { get; set; }
        public required string OportunidadeTxTipoAtividade { get; set; }
        public required string OportunidadeTxDisponibilidade { get; set; }
    }
}
