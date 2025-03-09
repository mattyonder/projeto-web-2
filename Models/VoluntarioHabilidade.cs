namespace PlataformaVoluntariado.Models
{
    public class VoluntarioHabilidade
    {
        public int VoluntarioId { get; set; }
        public Voluntario Voluntario { get; set; }
        public int HabilidadeId { get; set; }
        public Habilidade Habilidade { get; set; }
    }
}
