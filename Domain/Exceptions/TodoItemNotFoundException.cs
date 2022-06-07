using System;

namespace Domain.Exceptions
{
    public sealed class TodoItemNotFoundException : NotFoundException
    {
        public TodoItemNotFoundException(Guid todoItemId)
            : base($"The account with the identifier {todoItemId} was not found.")    
        {
        }
    }
}
