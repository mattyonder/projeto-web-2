using System.ComponentModel.DataAnnotations;

namespace PlataformaVoluntariado.Models
{
    public class Voluntario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public DateOnly DataNascimento { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Endereco { get; set; }
        public ICollection<VoluntarioHabilidade> VoluntarioHabilidades { get; set; } = new List<VoluntarioHabilidade>();
        public ICollection<VoluntarioAtividade> VoluntarioAtividades { get; set; } = new List<VoluntarioAtividade>();
    }
}
