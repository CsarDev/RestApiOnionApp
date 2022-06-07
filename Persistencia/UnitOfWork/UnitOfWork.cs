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
        public ITodoItemRepository TodoItemRepository { get; private set; }
        //public ITodoItemPgRepository TodoItemPgRepository { get; private set; }

        public UnitOfWork(ITodoItemRepository todoItemRepository/*, ITodoItemPgRepository todoItemPgRepository*/)
        {
            TodoItemRepository = todoItemRepository;
            //TodoItemPgRepository = todoItemPgRepository;
        }

        //Todo this when UnitOfWork has a generic DbContext
        //public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
