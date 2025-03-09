using Microsoft.EntityFrameworkCore;
using PlataformaVoluntariado.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PlataformaVoluntariado.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<HabilidadeAtividade> HabilidadesAtividades { get; set; }
        public DbSet<VoluntarioHabilidade> VoluntariosHabilidades { get; set; }
        public DbSet<VoluntarioAtividade> VoluntariosAtividades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HabilidadeAtividade>()
                .HasKey(ha => new { ha.AtividadeId, ha.HabilidadeId });

            modelBuilder.Entity<VoluntarioHabilidade>()
                .HasKey(vh => new { vh.VoluntarioId, vh.HabilidadeId });

            modelBuilder.Entity<VoluntarioAtividade>()
                .HasKey(va => new { va.AtividadeId, va.VoluntarioId });
        }
    }
}
