using System;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb2.Models;

namespace ProjetoWeb2.Data;

public class AppDbContext : DbContext
{
     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Adicione os DbSets para representar tabelas do banco
        public DbSet<Voluntarios> Voluntarios { get; set; }

}
