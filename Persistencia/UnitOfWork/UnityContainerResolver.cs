using Domain.Repositories;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Persistence.UnitOfWork
{
	public class UnityContainerResolver: IUnityContainerResolver
	{
		private IUnityContainer container;

		public UnityContainerResolver()
		{
			container = new UnityContainer().AddExtension(new Diagnostic()); ;
			RegisterTypes();
		}

		public void RegisterTypes()
		{
			container.RegisterType(typeof(IRepository<>), typeof(GenericRepository<>));
			container.RegisterType<ITodoItemHomeRepository, TodoItemHomeRepository>();
			container.RegisterType<ITodoItemWorkRepository, TodoItemWorkRepository>();
			container.AddNewExtension<DependencyOfDependencyExtension>();


			container.RegisterType<IUnitOfWork, UnitOfWork>();
		}

		public IUnitOfWork Resolver()
		{
			return container.Resolve<UnitOfWork>();
		}
	}
}
