using System.ComponentModel.DataAnnotations;

namespace PlataformaVoluntariado.Models
{
    public class Habilidade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        // Atividades que requerem essa habilidade
        public ICollection<HabilidadeAtividade> HabilidadeAtividades { get; set; } = new List<HabilidadeAtividade>();

        // Voluntários que possuem essa habilidade
        public ICollection<VoluntarioHabilidade> VoluntarioHabilidades { get; set; } = new List<VoluntarioHabilidade>();
    }
}
