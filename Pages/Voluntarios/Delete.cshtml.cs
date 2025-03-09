using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlataformaVoluntariado.Data;
using PlataformaVoluntariado.Models;

namespace PlataformaVoluntariado.Pages.Voluntarios
{
    public class DeleteModel : PageModel
    {
        private readonly PlataformaVoluntariado.Data.ApplicationDbContext _context;

        public DeleteModel(PlataformaVoluntariado.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Voluntario Voluntario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntario = await _context.Voluntarios.FirstOrDefaultAsync(m => m.Id == id);

            if (voluntario == null)
            {
                return NotFound();
            }
            else
            {
                Voluntario = voluntario;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntario = await _context.Voluntarios.FindAsync(id);
            if (voluntario != null)
            {
                Voluntario = voluntario;
                _context.Voluntarios.Remove(Voluntario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
