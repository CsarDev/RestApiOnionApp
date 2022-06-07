using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        ITodoItemRepository TodoItemRepository { get; }

        //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
