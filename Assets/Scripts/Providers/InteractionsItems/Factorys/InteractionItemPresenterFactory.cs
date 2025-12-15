using System.Collections.Generic;
using Assets.Scripts.Installers.Components;
using Assets.Scripts.Providers.Ui.Components;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Providers.InteractionsItems.Factorys {
	public class InteractionItemPresenterFactory :IInteractionItemPresenterFactory {
		private readonly DiContainer _diContainer;
		private GameObject _prefab;
		private List<InteractionItemPresenter> _instances = new();

		public InteractionItemPresenterFactory(DiContainer diContainer, PrefabLibrary prefabLibrary) {
			_diContainer = diContainer;
			_prefab = prefabLibrary.InteractionItemUiPrefab;
		}

		public InteractionItemPresenter GetInstance() {

			var result = _instances.Find(x => !x.gameObject.activeSelf);

			if (result != null)
				return result;

			var inst = Object.Instantiate(_prefab);

			result = inst.GetComponent<InteractionItemPresenter>();
			_diContainer.Inject(result);
			return result;

		}
	}
}
