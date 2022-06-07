using Domain.Contracts;

namespace Services.Abstractions
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItemDTO>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<TodoItemDTO> GetByIdAsync(Guid accountId, CancellationToken cancellationToken);

        Task<TodoItemDTO> CreateAsync(TodoItemForCreationDto accountForCreationDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid accountId, CancellationToken cancellationToken = default);
    }
}