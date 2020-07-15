using System.Threading.Tasks;

namespace SiteMeasure.Core.DataAccess
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
