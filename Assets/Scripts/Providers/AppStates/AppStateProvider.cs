using Assets.Scripts.Providers.AppStates.Common;
using Assets.Scripts.Providers.AppStates.Factorys;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Providers.AppStates {
	public class AppStateProvider :IAppStateProvider {
		public UnityAction OnStateChangeAction { get; set; }

		private readonly IAppStateFactory _factory;
		private AppState _currentState;
		private AppState _oldState;

		public AppState CurrentState => _currentState;
		public AppState OldState => _oldState;

		public string CurrentStateName => _currentState != null ? _currentState.Name : "";

		public string OldStateName => _oldState != null ? _oldState.Name : "";

		public AppStateProvider(IAppStateFactory factory) {
			_factory = factory;
		}

		public async UniTask SetState(string stateName) {
			if (_currentState != null && _currentState.Name == stateName)
				return;

			string oldStateName = "";

			if (_currentState != null) {
				_oldState = _currentState;
				await _oldState.Stop();
				oldStateName = _oldState.Name;
			}

			_currentState = _factory.GetInstance(stateName);
			await _currentState.Run(oldStateName);

			OnStateChangeAction?.Invoke();
		}
	}
}
