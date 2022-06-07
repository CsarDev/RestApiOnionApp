using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public sealed class TodoItemsHomeDbContext: DbContext
    {
        public TodoItemsHomeDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoItemsHomeDbContext).Assembly);
    }
}
