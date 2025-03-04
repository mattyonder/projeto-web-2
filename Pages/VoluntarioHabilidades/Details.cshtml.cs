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
    public class DetailsModel : PageModel
    {
        private readonly PlataformaVoluntariado.Data.PlataformaVoluntariadoContext _context;

        public DetailsModel(PlataformaVoluntariado.Data.PlataformaVoluntariadoContext context)
        {
            _context = context;
        }

        public VoluntarioHabilidade VoluntarioHabilidade { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntariohabilidade = await _context.VoluntarioHabilidade.FirstOrDefaultAsync(m => m.Id == id);
            if (voluntariohabilidade == null)
            {
                return NotFound();
            }
            else
            {
                VoluntarioHabilidade = voluntariohabilidade;
            }
            return Page();
        }
    }
}
