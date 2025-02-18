using System;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb2.Models;

namespace ProjetoWeb2.Data;

public class AppDbContext : DbContext
{
     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Adicione os DbSets para representar tabelas do banco
        public DbSet<Atividades> Atividades { get; set; }
        public DbSet<Avaliacoes> Avaliacoes { get; set; }
        public DbSet<Candidaturas> Candidaturas { get; set; }
        public DbSet<Habilidades> Habilidades { get; set; }
        public DbSet<Instituicoes> Instituicoes { get; set; }
        public DbSet<Oportunidades> Oportunidades { get; set; }
        public DbSet<VoluntarioHabilidades>  VoluntarioHabilidades { get; set; }
        public DbSet<Voluntarios> Voluntarios { get; set; }

}
