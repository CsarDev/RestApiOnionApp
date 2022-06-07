
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class TodoItemHomeConfiguration: IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable(nameof(TodoItem));

            builder.HasKey(todoItem => todoItem.Id);

            builder.Property(todoItem => todoItem.Id).ValueGeneratedOnAdd();

            builder.Property(todoItem => todoItem.Name)
                .HasMaxLength(100);

            builder.Property<bool>(todoItem => todoItem.IsComplete)
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(todoItem => todoItem.Secret)
                .HasMaxLength(255);

            builder.Property(account => account.DateCreated).IsRequired();


        }
    }
}
