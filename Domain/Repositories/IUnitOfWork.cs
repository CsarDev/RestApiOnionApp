using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        ITodoItemHomeRepository TodoItemHomeRepository { get; }
        ITodoItemWorkRepository TodoItemWorkRepository { get; }

        //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
