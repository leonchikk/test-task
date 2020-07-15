using SiteMeasure.Core.DataAccess;
using System;
using System.Threading.Tasks;

namespace SiteMeasure.Data.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SiteMeasureDbContext _dbContext;

        public UnitOfWork
        (
            SiteMeasureDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
