using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlataformaVoluntariado.Data;
using PlataformaVoluntariado.Models;

namespace PlataformaVoluntariado.Pages.Atividades
{
    public class DetailsModel : PageModel
    {
        private readonly PlataformaVoluntariado.Data.ApplicationDbContext _context;

        public DetailsModel(PlataformaVoluntariado.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Atividade Atividade { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividades.FirstOrDefaultAsync(m => m.Id == id);
            if (atividade == null)
            {
                return NotFound();
            }
            else
            {
                Atividade = atividade;
            }
            return Page();
        }
    }
}
