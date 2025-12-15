using System;
using Assets.Scripts.Providers.Ui.Base;
using Assets.Scripts.Providers.Ui.Common;
using Assets.Scripts.Providers.Ui.Controllers.Attributes;
using Assets.Scripts.Providers.Ui.Controllers.Interfaces;
using Assets.Scripts.Providers.Ui.Presenters.Base;
using Cysharp.Threading.Tasks;
using ModestTree;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Providers.Ui.Controllers.Base {
	public abstract class WindowPresenterController<TPresenter> :WindowPresenterControllerBase, IWindowPresenterController
	where TPresenter : WindowPresenter {
		protected IUiParents _uiParents;

		public TPresenter Presenter { get; private set; }
		public IWindowPresenter WindowPresenter => Presenter;

		[Inject]
		private void Initialize(IUiParents uiParents) {
			_uiParents = uiParents;
		}

		public async UniTask LoadPresenter() {
			if (Presenter == null)
				Presenter = await Preload();
		}

		public override async UniTask<bool> Show() {

			if (!await base.Show())
				return false;

			await LoadPresenter();

			if (Presenter == null)
				throw new NullReferenceException("No Exists prefab");

			Presenter.transform.SetAsLastSibling();
			await Presenter.Show();
			IsOpen = true;
			EmitOnPresenterVisibleChange();

			return true;
		}

		public override async UniTask<bool> Hide() {
			if (!await base.Hide())
				return false;

			if (Presenter == null)
				return false;

			await Presenter.Hide();
			IsOpen = false;
			EmitOnPresenterVisibleChange();

			return true;
		}

		private async UniTask<TPresenter> Preload() {
			Presenter = _presenterFactory.GetInstance<TPresenter>();

			Presenter.gameObject.SetActive(false);

			Presenter.transform.SetParent(GetParent());

			RectTransform rectTransform = Presenter.transform as RectTransform;
			rectTransform.SetAsLastSibling();
			rectTransform.localScale = Vector3.one;
			rectTransform.anchorMin = Vector2.zero;
			rectTransform.anchorMax = Vector2.one;
			rectTransform.sizeDelta = Vector2.zero;
			rectTransform.localPosition = Vector3.zero;
			rectTransform.anchoredPosition = Vector2.zero;

			_ = await Presenter.Initialize();

			AfterCreateWindow();

			return Presenter as TPresenter;
		}

		private Transform GetParent() {
			var attribute = this.GetType().GetAttribute<UiControllerAttribute>();

			var presenterType = attribute != null ? attribute.PresenterType : WindowPresenterType.Window;

			return presenterType switch {
				WindowPresenterType.Splash => _uiParents.Splash,
				WindowPresenterType.Popup => _uiParents.Popups,
				WindowPresenterType.Window or _ => _uiParents.Windows
			};
		}

		protected virtual void AfterCreateWindow() { }
	}
}
