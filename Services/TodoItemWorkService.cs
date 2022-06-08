using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;

namespace Services
{
    internal sealed class TodoItemWorkService : ITodoItemWorkService
    {
        private static IUnitOfWork _unitOfWork;
        private static IUnityContainerResolver _resolver;

        public TodoItemWorkService(IUnityContainerResolver unityContainerResolver) => _resolver = unityContainerResolver;

        public async Task<TodoItemDTO> GetByIdAsync(Guid todoItemId, CancellationToken cancellationToken)
        {
            _unitOfWork = _resolver.Resolver();

            var todoItem = /*await*/ _unitOfWork.TodoItemWorkRepository.Get(todoItemId/*, cancellationToken*/);

            if (todoItem is null)
            {
                throw new TodoItemNotFoundException(todoItemId);
            }

            var todoItemDto = todoItem.Adapt<TodoItemDTO>();

            return todoItemDto;
        }

        public async Task<IEnumerable<TodoItemDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            _unitOfWork = _resolver.Resolver();

            var todoItems = /*await*/ _unitOfWork.TodoItemWorkRepository.GetAll();

            var todoItemsDto = todoItems.Adapt<IEnumerable<TodoItemDTO>>();

            return todoItemsDto;
        }

        public async Task<TodoItemDTO> CreateAsync(TodoItemForCreationDto todoItemForCreationDto, CancellationToken cancellationToken = default)
        {
            var todoItem = todoItemForCreationDto.Adapt<TodoItem>();
            _unitOfWork = _resolver.Resolver();

            _unitOfWork.TodoItemWorkRepository.Insert(todoItem);

            //await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return todoItem.Adapt<TodoItemDTO>();
        }

        public async Task DeleteAsync(Guid todoItemId, CancellationToken cancellationToken = default)
        {
            _unitOfWork = _resolver.Resolver();

            var todoItem = /*await*/ _unitOfWork.TodoItemWorkRepository.Get(todoItemId/*, cancellationToken*/);

            if (todoItem is null)
            {
                throw new TodoItemNotFoundException(todoItemId);
            }


            _unitOfWork.TodoItemWorkRepository.Delete(todoItem);

            //await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
