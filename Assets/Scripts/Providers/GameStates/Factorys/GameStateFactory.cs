using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Providers.GameStates.Common;
using Zenject;

namespace Assets.Scripts.Providers.GameStates.Factorys {
	public class GameStateFactory :IGameStateFactory {
		private readonly DiContainer _diContainer;
		private List<GameState> _instancesList = new();

		public GameStateFactory(DiContainer diContainer) {
			_diContainer = diContainer;

			ReadController();
		}

		private void ReadController() {
			var childTypes = AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(s => s.GetTypes())
					.Where(type => type.IsSubclassOf(typeof(GameState)) && !type.IsAbstract);

			foreach (var item in childTypes) {
				var instance = Activator.CreateInstance(item) as GameState;

				_diContainer.Inject(instance);

				_instancesList.Add(instance);
			}
		}

		public T GetInstance<T>() where T : GameState {
			foreach (var item in _instancesList) {
				if (item.GetType() == typeof(T))
					return (T)item;
			}
			return default(T);
		}

		public GameState GetInstance(string stateName) {
			return _instancesList.Find(x => x.Name == stateName);
		}
	}
}
