using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ProjetoWeb2.Models
{
    public class Instituicoes
    {
        [Key]
        public int InstituicaoNrId { get; set; }
        public required string InstituicaoTxCnpj { get; set; }
        public required string InstituicaoTxNome { get; set; }
        public required string InstituicaoTxAreaAtuacao { get; set; }
        public required string InstituicaoTxMissao { get; set; }
        public required string InstituicaoTxWebsite { get; set; }
        public required string InstituicaoTxContato { get; set; }
        public required string InstituicaoTxEndereco { get; set; }
    }

}
