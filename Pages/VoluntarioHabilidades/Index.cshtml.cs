using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlataformaVoluntariado.Data;
using ProjetoWeb2.Models;

namespace PlataformaVoluntariado.Pages.VoluntarioHabilidades
{
    public class IndexModel : PageModel
    {
        private readonly PlataformaVoluntariado.Data.PlataformaVoluntariadoContext _context;

        public IndexModel(PlataformaVoluntariado.Data.PlataformaVoluntariadoContext context)
        {
            _context = context;
        }

        public IList<VoluntarioHabilidade> VoluntarioHabilidade { get;set; } = default!;

        public async Task OnGetAsync()
        {
            VoluntarioHabilidade = await _context.VoluntarioHabilidade.ToListAsync();
        }
    }
}
