using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlataformaVoluntariado.Data;
using ProjetoWeb2.Models;

namespace PlataformaVoluntariado.Pages.Atividades
{
    public class DeleteModel : PageModel
    {
        private readonly PlataformaVoluntariado.Data.PlataformaVoluntariadoContext _context;

        public DeleteModel(PlataformaVoluntariado.Data.PlataformaVoluntariadoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Atividade Atividade { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividade.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividade.FindAsync(id);
            if (atividade != null)
            {
                Atividade = atividade;
                _context.Atividade.Remove(Atividade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
