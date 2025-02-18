using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb2.Models
{
    public class Candidaturas
    {
        [Key]
        public int CandidaturaNrId { get; set; }
        public required int VoluntarioNrId { get; set; }
        public required int OportunidadeNrId { get; set; }
        public required string CandidaturaTxStatus { get; set; } = "Pendente";
        public required DateTime CandidaturaTxDataCandidatura { get; set; } = DateTime.Now;
    }
}
