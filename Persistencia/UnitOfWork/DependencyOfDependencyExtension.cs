using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Persistence.Contexts;
using Unity;
using Unity.Extension;

namespace Persistence.UnitOfWork
{
    public class DependencyOfDependencyExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<DbContext, TodoItemsHomeDbContext>();
            //Container.RegisterType<DbContext, PostgresDbContext >();
        }
    }
}
