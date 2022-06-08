using System;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITodoItemHomeService> _lazyTodoHomeItemService;
        private readonly Lazy<ITodoItemWorkService> _lazyTodoWorkItemService;


        public ServiceManager(IUnityContainerResolver unityContainerResolver)
        {
            _lazyTodoHomeItemService = new Lazy<ITodoItemHomeService>(() => new TodoItemHomeService(unityContainerResolver));
            _lazyTodoWorkItemService = new Lazy<ITodoItemWorkService>(() => new TodoItemWorkService(unityContainerResolver));

        }

        public ITodoItemHomeService TodoItemHomeService => _lazyTodoHomeItemService.Value;
        public ITodoItemWorkService TodoItemWorkService => _lazyTodoWorkItemService.Value;

    }
}
