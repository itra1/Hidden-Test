using System;
using System.Collections.Generic;
using Assets.Scripts.Common;
using Assets.Scripts.Providers.Ui.Presenters.Base;
using Assets.Scripts.Providers.Ui.Presenters.Settings;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Providers.Ui.Presenters.Factorys {
	public class WindowPresenterFactory :IWindowPresenterFactory {
		private readonly DiContainer _diContainer;
		private readonly IPresentersSettings _settings;
		private readonly Dictionary<Type, WindowPresenter> _prefabList = new();
		private readonly List<WindowPresenter> _instances = new();

		public WindowPresenterFactory(DiContainer container, IPresentersSettings settings) {
			_diContainer = container;
			_settings = settings;

			LoadResources();
		}

		private void LoadResources() {
			var presentersArray = Resources.LoadAll<WindowPresenter>(_settings.UiPresenters);

			for (int i = 0; i < presentersArray.Length; i++) {
				_prefabList.Add(presentersArray[i].GetType(), presentersArray[i]);
			}
		}

		public T GetInstance<T>() {
			var instanceType = _instances.Find(x => x.GetType() == typeof(T));

			try {
				if (instanceType != null)
					return instanceType.GetComponent<T>();
			} catch {
				throw new NullReferenceException("Не удается получить целевой компонент");
			}
			var prefab = _prefabList[typeof(T)];
			prefab.gameObject.SetActive(false);

			var inst = MonoBehaviour.Instantiate(prefab);

			_diContainer.Inject(inst);

			var components = inst.GetComponentsInChildren<IInjection>();

			foreach (var item in components) {
				_diContainer.Inject(item);
			}

			return inst.GetComponent<T>();
		}
	}
}
