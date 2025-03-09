namespace PlataformaVoluntariado.Models
{
    public class VoluntarioAtividade
    {
        public int AtividadeId { get; set; }
        public Atividade Atividade { get; set; }
        public int VoluntarioId { get; set; }
        public Voluntario Voluntario { get; set; }
        public DateTime DataInscricaoAtividade { get; set; }
    }
}
