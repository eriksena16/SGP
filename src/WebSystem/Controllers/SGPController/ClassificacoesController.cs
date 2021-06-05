using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGP.Data;
using SGP.Models;
using System.Linq;
using System.Threading.Tasks;


namespace SGP.Controllers
{
    public class ClassificacoesController : Controller
    {
        private readonly SGPContext _context;

        public ClassificacoesController(SGPContext context)
        {
            _context = context;
        }

        // GET: Classificacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classificacao.ToListAsync());
        }

        // GET: Classificacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificacao = await _context.Classificacao
                .FirstOrDefaultAsync(m => m.ClassificacaoID == id);
            if (classificacao == null)
            {
                return NotFound();
            }

            return View(classificacao);
        }

        // GET: Classificacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classificacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassificacaoID,Nome,taxa,VidaUtil")] Classificacao classificacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classificacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classificacao);
        }

        // GET: Classificacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificacao = await _context.Classificacao.FindAsync(id);
            if (classificacao == null)
            {
                return NotFound();
            }
            return View(classificacao);
        }

        // POST: Classificacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassificacaoID,Nome,taxa,VidaUtil")] Classificacao classificacao)
        {
            if (id != classificacao.ClassificacaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classificacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassificacaoExists(classificacao.ClassificacaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(classificacao);
        }

        // GET: Classificacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificacao = await _context.Classificacao
                .FirstOrDefaultAsync(m => m.ClassificacaoID == id);
            if (classificacao == null)
            {
                return NotFound();
            }

            return View(classificacao);
        }

        // POST: Classificacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classificacao = await _context.Classificacao.FindAsync(id);
            _context.Classificacao.Remove(classificacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassificacaoExists(int id)
        {
            return _context.Classificacao.Any(e => e.ClassificacaoID == id);
        }
    }
}
