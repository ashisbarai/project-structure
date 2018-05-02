using System.Threading.Tasks;

namespace Architecture.Core.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();

        Task<int> CommitAsync();
    }
}