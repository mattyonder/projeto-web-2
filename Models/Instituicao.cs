using System.ComponentModel.DataAnnotations;

namespace PlataformaVoluntariado.Models
{
    public class Instituicao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string AreaAtuacao { get; set; }
        [Required]
        public string Contato { get; set; }
        [Required]
        public string Endereco { get; set; }
        public ICollection<Atividade> Atividades { get; set; } = new List<Atividade>();
    }
}
