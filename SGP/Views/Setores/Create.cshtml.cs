using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGP.Data;
using SGP.Models.Setores;

namespace SGP.Views.Setores
{
    public class CreateModel : PageModel
    {
        private readonly SGP.Data.SGPContext _context;

        public CreateModel(SGP.Data.SGPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Setor Setor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Setor.Add(Setor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
