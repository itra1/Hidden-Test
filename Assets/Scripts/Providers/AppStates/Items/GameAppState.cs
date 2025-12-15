using Assets.Scripts.Providers.AppStates.Base;
using Assets.Scripts.Providers.AppStates.Common;
using Assets.Scripts.Providers.GameStates.Interfaces;
using Assets.Scripts.Providers.Ui.Controllers;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Providers.AppStates.Items {
	public class GameAppState :AppState {
		public override string Name => AppStateTypes.Game;

		private LoaderPresenterController _loaderPresenterController;
		private MenuPresenterController _menuPresenterController;
		private IGameStateSet _gameStateSet;

		[Inject]
		private void Inject(IGameStateSet gameStateSet) {
			_gameStateSet = gameStateSet;
		}

		public override async UniTask Run(string oldStateName) {
			_loaderPresenterController ??= _uiProvider.GetController<LoaderPresenterController>();
			_menuPresenterController ??= _uiProvider.GetController<MenuPresenterController>();

			_ = await _loaderPresenterController.Show();

			if (oldStateName == AppStateTypes.Menu && _menuPresenterController.IsOpen)
				_ = _menuPresenterController.Hide();

			await _gameStateSet.StateGame();

			_ = await _loaderPresenterController.Hide();
		}

		public override UniTask Stop() {
			return default;
		}
	}
}
