using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoWeb2.Models
{
    public class VoluntarioHabilidades
    {
        [Key]
        public int VoluntarioHabilidadesNrId { get; set; }
        public required int VoluntarioNrId { get; set; }
        public required int VabilidadeNrId { get; set; }
    }
}
