using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlataformaVoluntariado.Models
{
    public class Atividade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public int InstituicaoId { get; set; }

        [ForeignKey("InstituicaoId")]
        public Instituicao Instituicao { get; set; }

        public ICollection<HabilidadeAtividade> HabilidadeAtividades { get; set; } = new List<HabilidadeAtividade>();

        public ICollection<VoluntarioAtividade> VoluntarioAtividades { get; set; } = new List<VoluntarioAtividade>();
    }
}
