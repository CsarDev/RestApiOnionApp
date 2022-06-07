using System;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITodoItemService> _lazyTodoItemService;

        public ServiceManager(IUnityContainerResolver unityContainerResolver)
        {
            _lazyTodoItemService = new Lazy<ITodoItemService>(() => new TodoItemHomeService(unityContainerResolver));
        }

        public ITodoItemService TodoItemHomeService => _lazyTodoItemService.Value;
    }
}
