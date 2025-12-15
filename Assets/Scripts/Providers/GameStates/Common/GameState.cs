using Assets.Scripts.Providers.Ui;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Providers.GameStates.Common {
	public abstract class GameState {
		protected DiContainer _diContainer;
		protected IUiProvider _uiProvider;
		protected IGameStateProvider _gameStateProvider;

		[Inject]
		public void Constructor(DiContainer diContainer, IUiProvider uiProvider) {
			_diContainer = diContainer;
			_uiProvider = uiProvider;
		}

		public void SetGameStateProvider(IGameStateProvider gameStateProvider) {
			_gameStateProvider = gameStateProvider;
		}

		public abstract string Name { get; }

		public abstract UniTask Run(string oldStateName);
		public abstract UniTask Stop();
	}
}
