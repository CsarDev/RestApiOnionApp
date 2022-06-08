using Domain.Entities;
using Domain.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public sealed class TodoItemWorkRepository : GenericRepository<TodoItem>, ITodoItemWorkRepository
    {
        public TodoItemWorkRepository(TodoItemsWorkDbContext context) : base(context)
        {

        }
    }

}
