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
    public class DetailsModel : PageModel
    {
        private readonly PlataformaVoluntariado.Data.ApplicationDbContext _context;

        public DetailsModel(PlataformaVoluntariado.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Habilidade Habilidade { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidade = await _context.Habilidades.FirstOrDefaultAsync(m => m.Id == id);
            if (habilidade == null)
            {
                return NotFound();
            }
            else
            {
                Habilidade = habilidade;
            }
            return Page();
        }
    }
}
