using Assets.Scripts.Providers.GameStates.Base;
using Assets.Scripts.Providers.GameStates.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Providers.GameStates {
	public class GameStateHandler :IGameState, IGameStateSet {
		public UnityEvent<string, string> OnStateChange { get; set; } = new();

		private readonly IGameStateProvider _provider;
		public string State => _provider.CurrentState == null ? "" : _provider.CurrentState.Name;
		public string OldState => _provider.OldState == null ? "" : _provider.OldState.Name;

		public GameStateHandler(IGameStateProvider provider) {
			_provider = provider;

			_provider.OnStateChangeAction = OnStateChangeListener;
		}

		private void OnStateChangeListener() {
			OnStateChange?.Invoke(_provider.CurrentStateName, _provider.OldStateName);
		}

		public async UniTask StateGame() {
			await _provider.SetState(GameStateTypes.Game);
		}

		public async UniTask StateWin() {
			await _provider.SetState(GameStateTypes.Win);
		}

		public async UniTask StateLoss() {
			await _provider.SetState(GameStateTypes.Loss);
		}

		public async UniTask StateNone() {
			await _provider.SetState(GameStateTypes.None);
		}
	}
}
