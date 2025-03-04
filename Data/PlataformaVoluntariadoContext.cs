using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb2.Models;

namespace PlataformaVoluntariado.Data
{
    public class PlataformaVoluntariadoContext : DbContext
    {
        public PlataformaVoluntariadoContext (DbContextOptions<PlataformaVoluntariadoContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoWeb2.Models.Voluntario> Voluntario { get; set; } = default!;
        public DbSet<ProjetoWeb2.Models.Instituicao> Instituicao { get; set; } = default!;
        public DbSet<ProjetoWeb2.Models.Atividade> Atividade { get; set; } = default!;
        public DbSet<ProjetoWeb2.Models.Habilidade> Habilidade { get; set; } = default!;
        public DbSet<ProjetoWeb2.Models.VoluntarioAtividade> VoluntarioAtividade { get; set; } = default!;
        public DbSet<ProjetoWeb2.Models.VoluntarioHabilidade> VoluntarioHabilidade { get; set; } = default!;
    }
}
