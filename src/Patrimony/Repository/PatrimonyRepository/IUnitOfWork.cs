using System.Threading.Tasks;
namespace SGP.Patrimony.Repository.PatrimonyRepository
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}