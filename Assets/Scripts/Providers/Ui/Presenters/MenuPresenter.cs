using Assets.Scripts.Providers.Ui.Presenters.Base;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Providers.Ui.Presenters {
	public class MenuPresenter :WindowPresenter {
		public UnityAction OnPlayAction;

		[SerializeField] private Button _playButton;

		public override async UniTask<bool> Initialize() {
			if (!await base.Initialize()) {
				return false;
			}

			_playButton.onClick.AddListener(PlayButtonTouch);

			return true;
		}

		private void PlayButtonTouch() {
			OnPlayAction?.Invoke();
		}
	}
}
