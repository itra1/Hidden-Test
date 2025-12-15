using Assets.Scripts.Providers.AppStates.Base;
using Assets.Scripts.Providers.AppStates.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Providers.AppStates {
	public class AppStateHandler :IAppState, IAppStateSet {
		public UnityEvent<string, string> OnStateChange { get; set; } = new();
		private readonly IAppStateProvider _provider;
		public string State => _provider.CurrentState == null ? "" : _provider.CurrentState.Name;
		public string OldState => _provider.OldState == null ? "" : _provider.OldState.Name;

		public AppStateHandler(IAppStateProvider provider) {
			_provider = provider;

			_provider.OnStateChangeAction = OnStateChangeListener;
		}

		private void OnStateChangeListener() {
			OnStateChange?.Invoke(_provider.CurrentStateName, _provider.OldStateName);
		}

		public async UniTask StateGame() {
			await _provider.SetState(AppStateTypes.Game);
		}

		public async UniTask StateLoading() {
			await _provider.SetState(AppStateTypes.Loading);
		}

		public async UniTask StateMenu() {
			await _provider.SetState(AppStateTypes.Menu);
		}
	}
}
