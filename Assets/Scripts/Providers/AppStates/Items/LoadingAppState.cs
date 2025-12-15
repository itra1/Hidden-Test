
using Assets.Scripts.Providers.AppStates.Base;
using Assets.Scripts.Providers.AppStates.Common;
using Assets.Scripts.Providers.Ui.Controllers;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Providers.AppStates.Items {
	public class LoadingAppState :AppState {
		private LoaderPresenterController _loaderPresenterController;
		public override string Name => AppStateTypes.Loading;

		public override UniTask Run(string oldStateName) {

			_loaderPresenterController ??= _uiProvider.GetController<LoaderPresenterController>();

			_ = _loaderPresenterController.Show();
			return default;
		}

		public override UniTask Stop() {
			_ = _loaderPresenterController.Hide();
			return default;
		}
	}
}
