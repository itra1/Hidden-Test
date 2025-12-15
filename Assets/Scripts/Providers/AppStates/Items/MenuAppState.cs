
using Assets.Scripts.Providers.AppStates.Base;
using Assets.Scripts.Providers.AppStates.Common;
using Assets.Scripts.Providers.Ui.Controllers;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Providers.AppStates.Items {
	public class MenuAppState :AppState {
		private MenuPresenterController _menuPresenterController;
		public override string Name => AppStateTypes.Menu;

		public override UniTask Run(string oldStateName) {

			_menuPresenterController ??= _uiProvider.GetController<MenuPresenterController>();

			_ = _menuPresenterController.Show();
			return default;
		}

		public override UniTask Stop() {
			return default;
		}
	}
}
