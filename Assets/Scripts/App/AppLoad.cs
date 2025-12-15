using Assets.Scripts.Providers.AppStates.Interfaces;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.App {
	public class AppLoad :IInitializable {
		private readonly IAppStateSet _appState;

		public AppLoad(IAppStateSet appState) {
			_appState = appState;
		}
		public void Initialize() {
			_ = InitializeAsync();
		}
		public async UniTask InitializeAsync() {
			_ = _appState.StateLoading();
			await UniTask.Delay(1000);
			_ = _appState.StateMenu();
		}
	}
}
