using Assets.Scripts.Game;
using Assets.Scripts.Providers.GameStates.Base;
using Assets.Scripts.Providers.GameStates.Common;
using Assets.Scripts.Providers.Ui.Controllers;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Providers.GameStates.Items {
	public class GameGameState :GameState {
		private GamePlayPresenterController _gamePlayPresenterController;
		private IGameBehaviour _gameBehaviour;

		public override string Name => GameStateTypes.Game;

		[Inject]
		private void Inject(IGameBehaviour levelsHandler) {
			_gameBehaviour = levelsHandler;
		}

		public override UniTask Run(string oldStateName) {

			if (oldStateName == GameStateTypes.Win) {
				var winPresenter = _uiProvider.GetController<GameWinPresenterController>();
				_ = winPresenter.Hide();
			}
			if (oldStateName == GameStateTypes.Loss) {
				var lossPresenter = _uiProvider.GetController<GameLossPresenterController>();
				_ = lossPresenter.Hide();
			}

			_gamePlayPresenterController ??= _uiProvider.GetController<GamePlayPresenterController>();
			_ = _gamePlayPresenterController.Show();

			_gameBehaviour.SetLevel(0);
			return default;
		}

		public override UniTask Stop() {
			return default;
		}
	}
}
