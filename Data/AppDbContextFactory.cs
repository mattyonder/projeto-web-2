using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ProjetoWeb2.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=projetoweb2;Trusted_Connection=True;TrustServerCertificate=True;");
           // "Server=localhost;Database=projetoweb2;Trusted_Connection=True;TrustServerCertificate=True;"

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
