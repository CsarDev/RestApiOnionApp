using Domain.Entities;
using Domain.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    internal sealed class TodoItemHomeRepository : GenericRepository<TodoItem>, ITodoItemRepository
    {
        public TodoItemHomeRepository(TodoItemsHomeDbContext context) : base(context)
        {

        }
    }

}
