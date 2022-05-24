using System.Threading.Tasks;
namespace SGP.Patrimony.Repository.PatrimonyRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SGPContext _context;
        public UnitOfWork(SGPContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}