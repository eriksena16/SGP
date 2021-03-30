using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGP.Data;
using SGP.Models.Setores;

namespace SGP.Views.Setores
{
    public class DeleteModel : PageModel
    {
        private readonly SGP.Data.SGPContext _context;

        public DeleteModel(SGP.Data.SGPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Setor Setor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Setor = await _context.Setor.FirstOrDefaultAsync(m => m.SetorID == id);

            if (Setor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Setor = await _context.Setor.FindAsync(id);

            if (Setor != null)
            {
                _context.Setor.Remove(Setor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
