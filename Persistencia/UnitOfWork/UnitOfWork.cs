using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        public ITodoItemHomeRepository TodoItemHomeRepository { get; private set; }
        public ITodoItemWorkRepository TodoItemWorkRepository { get; private set; }

        public UnitOfWork(ITodoItemHomeRepository todoItemRepository, ITodoItemWorkRepository todoItemWorkRepository)
        {
            TodoItemHomeRepository = todoItemRepository;
            TodoItemWorkRepository = todoItemWorkRepository;
        }

        //Todo this when UnitOfWork has a generic DbContext
        //public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
