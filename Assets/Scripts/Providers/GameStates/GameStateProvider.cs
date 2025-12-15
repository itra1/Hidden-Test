using Assets.Scripts.Providers.GameStates.Base;
using Assets.Scripts.Providers.GameStates.Common;
using Assets.Scripts.Providers.GameStates.Factorys;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Providers.GameStates {
	public class GameStateProvider :IGameStateProvider {

		public UnityAction OnStateChangeAction { get; set; }

		private IGameStateFactory _factory;
		private GameState _currentState;
		private GameState _oldState;

		public GameState CurrentState => _currentState;
		public GameState OldState => _oldState;

		public string CurrentStateName => _currentState != null ? _currentState.Name : "";

		public string OldStateName => _oldState != null ? _oldState.Name : "";

		public GameStateProvider(IGameStateFactory factory) {
			_factory = factory;

			_ = SetState(GameStateTypes.None);
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
			_currentState.SetGameStateProvider(this);
			await _currentState.Run(oldStateName);

			OnStateChangeAction?.Invoke();
		}
	}
}
