namespace PlataformaVoluntariado.Models
{
    public class HabilidadeAtividade
    {
        public int AtividadeId { get; set; }
        public Atividade Atividade { get; set; }
        public int HabilidadeId { get; set; }
        public Habilidade Habilidade { get; set; }
    }
}
