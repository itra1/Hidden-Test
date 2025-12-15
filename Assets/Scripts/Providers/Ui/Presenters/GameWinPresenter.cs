using Assets.Scripts.Providers.Ui.Presenters.Base;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Providers.Ui.Presenters {
	public class GameWinPresenter :WindowPresenter {
		public UnityAction OnRestartAction;
		public UnityAction OnMenuAction;

		[SerializeField] private Button _restartButton;
		[SerializeField] private Button _menuButton;

		public override async UniTask<bool> Initialize() {
			if (!await base.Initialize()) {
				return false;
			}

			_restartButton.onClick.AddListener(RestartButtonTouch);
			_menuButton.onClick.AddListener(MenuButtonTouch);

			return true;
		}

		private void MenuButtonTouch() {
			OnMenuAction?.Invoke();
		}

		private void RestartButtonTouch() {
			OnRestartAction?.Invoke();
		}
	}
}
