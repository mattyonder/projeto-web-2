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
    public class DeleteModel : PageModel
    {
        private readonly PlataformaVoluntariado.Data.PlataformaVoluntariadoContext _context;

        public DeleteModel(PlataformaVoluntariado.Data.PlataformaVoluntariadoContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntariohabilidade = await _context.VoluntarioHabilidade.FindAsync(id);
            if (voluntariohabilidade != null)
            {
                VoluntarioHabilidade = voluntariohabilidade;
                _context.VoluntarioHabilidade.Remove(VoluntarioHabilidade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
