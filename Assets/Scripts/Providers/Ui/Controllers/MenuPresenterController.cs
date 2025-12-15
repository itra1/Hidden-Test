using Assets.Scripts.Providers.AppStates.Interfaces;
using Assets.Scripts.Providers.Ui.Base;
using Assets.Scripts.Providers.Ui.Controllers.Attributes;
using Assets.Scripts.Providers.Ui.Controllers.Base;
using Assets.Scripts.Providers.Ui.Presenters;

namespace Assets.Scripts.Providers.Ui.Controllers {
	[UiController(WindowPresenterType.Window, WindowPresenterNames.Menu)]
	public class MenuPresenterController :WindowPresenterController<MenuPresenter> {


		protected override void AfterCreateWindow() {
			base.AfterCreateWindow();

			Presenter.OnPlayAction = OnPlayListener;
		}

		private void OnPlayListener() {

			IAppStateSet appState = _diContainer.Resolve<IAppStateSet>();
			appState.StateGame();
		}
	}
}
