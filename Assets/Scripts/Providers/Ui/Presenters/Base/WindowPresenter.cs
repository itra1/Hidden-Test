using Assets.Scripts.Providers.Ui.Animations;
using Assets.Scripts.Providers.Ui.Presenters.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Providers.Ui.Presenters.Base
{
	public abstract class WindowPresenter : MonoBehaviour, IWindowPresenter
	{
		private IUiVisibleHandler[] _visibleElements;
		protected IShowPresenterAnimation _showPresenterAnimation;
		protected IHidePresenterAnimation _hidePresenterAnimation;

		public bool IsVisible { get; protected set; }

		public virtual async UniTask<bool> Initialize()
		{
			_visibleElements = GetComponentsInChildren<IUiVisibleHandler>(true);

			_showPresenterAnimation = GetComponent<IShowPresenterAnimation>();
			_hidePresenterAnimation = GetComponent<IHidePresenterAnimation>();

			return await UniTask.FromResult(true);
		}

		public virtual async UniTask Show()
		{
			IsVisible = true;
			for (int i = 0; i < _visibleElements.Length; i++)
				_visibleElements[i].Show();

			if (_showPresenterAnimation != null)
				await _showPresenterAnimation.ShowAnimation();
			else
				gameObject.SetActive(true);
		}

		public virtual async UniTask Hide()
		{
			IsVisible = false;
			for (int i = 0; i < _visibleElements.Length; i++)
				_visibleElements[i].Hide();

			if (_hidePresenterAnimation != null)
				await _hidePresenterAnimation.HideAnimation();
			else
				gameObject.SetActive(false);
		}
	}
}