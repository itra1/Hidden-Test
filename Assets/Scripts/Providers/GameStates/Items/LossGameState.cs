using Assets.Scripts.Game;
using Assets.Scripts.Providers.AppStates.Interfaces;
using Assets.Scripts.Providers.GameStates.Base;
using Assets.Scripts.Providers.Ui.Controllers;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Providers.GameStates.Items {
	public class LossGameState :ResultGameState {

		private GameLossPresenterController _lossPresenter;
		public override string Name => GameStateTypes.Loss;
		private IGameBehaviour _gameBehaviour;

		[Inject]
		private void Inject(IGameBehaviour levelsHandler) {
			_gameBehaviour = levelsHandler;
		}

		public override UniTask Run(string oldStateName) {

			_lossPresenter ??= _uiProvider.GetController<GameLossPresenterController>();
			_ = _lossPresenter.Show();

			_lossPresenter.OnMenuAction = MenuActionListener;
			_lossPresenter.OnRestartAction = RestartActionListener;

			return default;
		}

		private void RestartActionListener() {
			_ = _gameStateProvider.SetState(GameStateTypes.Game);
		}

		private void MenuActionListener() {
			_ = _gameStateProvider.SetState(GameStateTypes.None);
			var appState = _diContainer.Resolve<IAppStateSet>();
			_ = appState.StateMenu();
		}

		public override UniTask Stop() {
			return default;
		}
	}
}
