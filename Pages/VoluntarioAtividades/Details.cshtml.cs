using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlataformaVoluntariado.Data;
using ProjetoWeb2.Models;

namespace PlataformaVoluntariado.Pages.VoluntarioAtividades
{
    public class DetailsModel : PageModel
    {
        private readonly PlataformaVoluntariado.Data.PlataformaVoluntariadoContext _context;

        public DetailsModel(PlataformaVoluntariado.Data.PlataformaVoluntariadoContext context)
        {
            _context = context;
        }

        public VoluntarioAtividade VoluntarioAtividade { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarioatividade = await _context.VoluntarioAtividade.FirstOrDefaultAsync(m => m.Id == id);
            if (voluntarioatividade == null)
            {
                return NotFound();
            }
            else
            {
                VoluntarioAtividade = voluntarioatividade;
            }
            return Page();
        }
    }
}
