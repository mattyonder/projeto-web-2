using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlataformaVoluntariado.Data;
using PlataformaVoluntariado.Models;

namespace PlataformaVoluntariado.Pages.Instituicoes
{
    public class DeleteModel : PageModel
    {
        private readonly PlataformaVoluntariado.Data.ApplicationDbContext _context;

        public DeleteModel(PlataformaVoluntariado.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Instituicao Instituicao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.FirstOrDefaultAsync(m => m.Id == id);

            if (instituicao == null)
            {
                return NotFound();
            }
            else
            {
                Instituicao = instituicao;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.FindAsync(id);
            if (instituicao != null)
            {
                Instituicao = instituicao;
                _context.Instituicoes.Remove(Instituicao);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
