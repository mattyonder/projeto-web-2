using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlataformaVoluntariado.Data;
using PlataformaVoluntariado.Models;

namespace PlataformaVoluntariado.Pages.Habilidades
{
    public class IndexModel : PageModel
    {
        private readonly PlataformaVoluntariado.Data.ApplicationDbContext _context;

        public IndexModel(PlataformaVoluntariado.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Habilidade> Habilidade { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Habilidade = await _context.Habilidades.ToListAsync();
        }
    }
}
