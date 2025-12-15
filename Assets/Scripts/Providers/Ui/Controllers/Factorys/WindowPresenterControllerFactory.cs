using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Providers.Ui.Controllers.Attributes;
using Assets.Scripts.Providers.Ui.Controllers.Base;
using Assets.Scripts.Providers.Ui.Controllers.Interfaces;
using ModestTree;
using Zenject;

namespace Assets.Scripts.Providers.Ui.Controllers.Factorys
{
	public class WindowPresenterControllerFactory : IWindowPresenterControllerFactory
	{
		private readonly DiContainer _diContainer;
		private Dictionary<IUiControllerAttribute, IWindowPresenterController> _instancesList = new();

		public WindowPresenterControllerFactory(DiContainer diContainer)
		{
			_diContainer = diContainer;
			ReadControllers();
		}

		private void ReadControllers()
		{
			_instancesList.Clear();

			Type parentType = typeof(WindowPresenterControllerBase);

			var childTypes = AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(s => s.GetTypes())
					.Where(type => type.IsSubclassOf(parentType) && !type.IsAbstract);

			foreach (var item in childTypes)
			{
				var attribut = item.GetAttribute<UiControllerAttribute>();

				if (attribut == null)
					continue;

				var instance = Activator.CreateInstance(item) as IWindowPresenterController;

				_diContainer.Inject(instance);

				_instancesList.Add(attribut, instance);
			}
		}
		public T GetInstance<T>()
		{
			foreach (var item in _instancesList.Values)
			{
				if (item.GetType() == typeof(T))
					return (T) item;
			}
			return default(T);
		}
	}
}
