using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGP.Data;
using SGP.Models.Setores;

namespace SGP.Views.Setores
{
    public class EditModel : PageModel
    {
        private readonly SGP.Data.SGPContext _context;

        public EditModel(SGP.Data.SGPContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Setor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetorExists(Setor.SetorID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SetorExists(int id)
        {
            return _context.Setor.Any(e => e.SetorID == id);
        }
    }
}
