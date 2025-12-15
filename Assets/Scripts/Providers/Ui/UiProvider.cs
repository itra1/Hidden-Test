using System.Collections.Generic;
using Assets.Scripts.Providers.Ui.Controllers.Factorys;
using Assets.Scripts.Providers.Ui.Controllers.Interfaces;

namespace Assets.Scripts.Providers.Ui {
	public class UiProvider :IUiProvider {
		private readonly IWindowPresenterControllerFactory _controllersFactory;
		private Stack<IWindowPresenterController> _controllersStack = new();
		public UiProvider(IWindowPresenterControllerFactory controllersFactory) {
			_controllersFactory = controllersFactory;
		}

		public T GetController<T>() {
			T controller = _controllersFactory.GetInstance<T>();

			//if (controller != null) {
			//	controller.OnPresenterVisibleChange.RemoveListener(PresenterVisibleChangeListener);
			//	controller.OnPresenterVisibleChange.AddListener(PresenterVisibleChangeListener);
			//}

			return controller;
		}

	}
}
