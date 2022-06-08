using Domain.Entities;
using Domain.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public sealed class TodoItemHomeRepository : GenericRepository<TodoItem>, ITodoItemHomeRepository
    {
        public TodoItemHomeRepository(TodoItemsHomeDbContext context) : base(context)
        {

        }
    }

}
