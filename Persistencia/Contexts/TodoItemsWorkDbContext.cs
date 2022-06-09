using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public sealed class TodoItemsWorkDbContext: DbContext
    {
        private const string connectionString = "User ID =postgres;Password=postgres;Host=onionarchitecture.pgdb;Port=5432;Database=TodoWork; Integrated Security=true;Pooling=true;";

        public TodoItemsWorkDbContext(DbContextOptions<TodoItemsWorkDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoItemsWorkDbContext).Assembly);
    }
}
