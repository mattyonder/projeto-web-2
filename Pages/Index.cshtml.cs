using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlataformaVoluntariado.Data;
using PlataformaVoluntariado.Models;

namespace PlataformaVoluntariado.Pages;

public class IndexModel(ApplicationDbContext _context, ILogger<IndexModel> _logger) : PageModel
{
    public ICollection<Habilidade> Habilidades { get; set; }
    public string Title { get; set; }


    public void OnGet()
    {
        Habilidades = _context.Habilidades.ToList();
        Title = "Plataforma de Voluntariado";

    }
}
