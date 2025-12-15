using Assets.Scripts.Providers.Ui;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Providers.AppStates.Common {
	public abstract class AppState {
		protected DiContainer _diContainer;
		protected IUiProvider _uiProvider;

		[Inject]
		public void Constructor(DiContainer diContainer, IUiProvider uiProvider) {
			_diContainer = diContainer;
			_uiProvider = uiProvider;
		}

		public abstract string Name { get; }

		public abstract UniTask Run(string oldStateName);
		public abstract UniTask Stop();
	}
}
