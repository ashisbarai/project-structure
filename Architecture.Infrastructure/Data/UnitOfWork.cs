using System.Threading.Tasks;
using Architecture.Core.Interfaces;

namespace Architecture.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int Commit()
        {
            return _appDbContext.Commit();
        }

        public Task<int> CommitAsync()
        {
            return _appDbContext.CommitAsync();
        }
    }
}