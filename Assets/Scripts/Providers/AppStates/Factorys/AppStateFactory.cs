using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Providers.AppStates.Common;
using Zenject;

namespace Assets.Scripts.Providers.AppStates.Factorys {
	public class AppStateFactory :IAppStateFactory {
		private readonly DiContainer _diContainer;
		private List<AppState> _instancesList = new();

		public AppStateFactory(DiContainer diContainer) {
			_diContainer = diContainer;

			ReadController();
		}

		private void ReadController() {
			var childTypes = AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(s => s.GetTypes())
					.Where(type => type.IsSubclassOf(typeof(AppState)) && !type.IsAbstract);

			foreach (var item in childTypes) {
				var instance = Activator.CreateInstance(item) as AppState;

				_diContainer.Inject(instance);

				_instancesList.Add(instance);
			}
		}

		public T GetInstance<T>() where T : AppState {
			foreach (var item in _instancesList) {
				if (item.GetType() == typeof(T))
					return (T)item;
			}
			return default(T);
		}

		public AppState GetInstance(string stateName) {
			return _instancesList.Find(x => x.Name == stateName);
		}
	}
}
