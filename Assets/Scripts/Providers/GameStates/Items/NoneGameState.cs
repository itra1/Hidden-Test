using Assets.Scripts.Providers.GameStates.Base;
using Assets.Scripts.Providers.GameStates.Common;
using Assets.Scripts.Providers.Ui.Controllers;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Providers.GameStates.Items {
	public class NoneGameState :GameState {
		public override string Name => GameStateTypes.None;

		public override UniTask Run(string oldStateName) {

			if (oldStateName == GameStateTypes.Win) {
				var winPresenter = _uiProvider.GetController<GameWinPresenterController>();
				_ = winPresenter.Hide();
			}
			if (oldStateName == GameStateTypes.Loss) {
				var lossPresenter = _uiProvider.GetController<GameLossPresenterController>();
				_ = lossPresenter.Hide();
			}
			var gamePlay = _uiProvider.GetController<GamePlayPresenterController>();
			_ = gamePlay.Hide();
			return default;
		}

		public override UniTask Stop() {
			return default;
		}
	}
}
