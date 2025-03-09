using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlataformaVoluntariado.Data;
using PlataformaVoluntariado.Models;

namespace PlataformaVoluntariado.Pages.Voluntarios
{
    public class CreateModel : PageModel
    {
        private readonly PlataformaVoluntariado.Data.ApplicationDbContext _context;

        public CreateModel(PlataformaVoluntariado.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Voluntario Voluntario { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(Voluntario.Nome.ToString());
                var error = ModelState.ErrorCount;
                Console.WriteLine("Erros contados", error);
                return Page();
            }

            _context.Voluntarios.Add(Voluntario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
