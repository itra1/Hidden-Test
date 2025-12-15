using Assets.Scripts.Providers.Ui.Base;
using Assets.Scripts.Providers.Ui.Controllers.Attributes;
using Assets.Scripts.Providers.Ui.Controllers.Base;
using Assets.Scripts.Providers.Ui.Presenters;
using UnityEngine.Events;

namespace Assets.Scripts.Providers.Ui.Controllers {
	[UiController(WindowPresenterType.Popup, WindowPresenterNames.GameLoss)]
	public class GameLossPresenterController :WindowPresenterController<GameLossPresenter> {
		public UnityAction OnMenuAction;
		public UnityAction OnRestartAction;

		protected override void AfterCreateWindow() {
			base.AfterCreateWindow();

			Presenter.OnMenuAction = MenuActionListener;
			Presenter.OnRestartAction = RestartActionListener;
		}

		private void RestartActionListener() {
			OnRestartAction?.Invoke();
		}

		private void MenuActionListener() {
			OnMenuAction?.Invoke();
		}
	}
}
