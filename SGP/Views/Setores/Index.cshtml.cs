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
    public class IndexModel : PageModel
    {
        private readonly SGP.Data.SGPContext _context;

        public IndexModel(SGP.Data.SGPContext context)
        {
            _context = context;
        }

        public IList<Setor> Setor { get;set; }

        public async Task OnGetAsync()
        {
            Setor = await _context.Setor.ToListAsync();
        }
    }
}
