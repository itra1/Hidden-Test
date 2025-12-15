using Assets.Scripts.Providers.Ui.Controllers.Interfaces;
using Assets.Scripts.Providers.Ui.Presenters.Factorys;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts.Providers.Ui.Controllers.Base {
	public abstract class WindowPresenterControllerBase {
		public UnityEvent<IWindowPresenterController> OnPresenterVisibleChange { get; set; } = new();
		protected IWindowPresenterFactory _presenterFactory;
		protected DiContainer _diContainer;

		public bool IsOpen { get; protected set; }

		[Inject]
		private void Constructor(DiContainer diContainer, IWindowPresenterFactory presenterFactory) {
			_presenterFactory = presenterFactory;
			_diContainer = diContainer;
		}

		public virtual async UniTask<bool> Show() {
			if (IsOpen)
				return await UniTask.FromResult(false);
			return await UniTask.FromResult(true);
		}

		public virtual async UniTask<bool> Hide() {
			if (!IsOpen)
				return await UniTask.FromResult(false);
			return await UniTask.FromResult(true);
		}

		protected void EmitOnPresenterVisibleChange() {
			OnPresenterVisibleChange?.Invoke(this as IWindowPresenterController);
		}
	}
}
