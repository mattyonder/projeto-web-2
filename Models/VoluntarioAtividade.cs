namespace ProjetoWeb2.Models
{
    public class VoluntarioAtividade
    {
        public int Id { get; set; }
        public required int AtividadeId { get; set; }
        public required int HabilidadeId { get; set; }
    }
}
