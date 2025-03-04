using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlataformaVoluntariado.Data;
using ProjetoWeb2.Models;

namespace PlataformaVoluntariado.Pages.Habilidades
{
    public class CreateModel : PageModel
    {
        private readonly PlataformaVoluntariado.Data.PlataformaVoluntariadoContext _context;

        public CreateModel(PlataformaVoluntariado.Data.PlataformaVoluntariadoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Habilidade Habilidade { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Habilidade.Add(Habilidade);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
