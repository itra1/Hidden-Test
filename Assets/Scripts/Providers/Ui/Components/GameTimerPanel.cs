using Assets.Scripts.Common;
using Assets.Scripts.Game.Handlers.Timers;
using Assets.Scripts.Providers.Ui.Presenters.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Providers.Ui.Components {
	public class GameTimerPanel :MonoBehaviour, IInjection, IUiVisibleHandler {

		[SerializeField] private TMP_Text _timerLabel;
		private IGameTimerHandler _timerHandler;

		[Inject]
		public void Constructor(IGameTimerHandler timerHandler) {
			_timerHandler = timerHandler;

			_timerHandler.OnTimerVisibleChange.AddListener(OnTimerVisibleListener);
			_timerHandler.OnTimerUpdate.AddListener(OnTimerUpdateListener);
		}

		public void Show() {
			SetVisibleTimer(_timerHandler.IsVisible);

			if (_timerHandler.IsVisible) {
				TimerUpdate(_timerHandler.TimerValue);
			}
		}

		public void Hide() {

		}

		private void OnTimerUpdateListener(int value) {
			TimerUpdate(value);
		}

		private void OnTimerVisibleListener(bool value) {
			SetVisibleTimer(value);
		}

		private void SetVisibleTimer(bool value) {
			_timerLabel.gameObject.SetActive(value);
		}

		private void TimerUpdate(int value) {
			var minut = value / 60;
			var seconds = value % 60;

			_timerLabel.text = $"{minut:00}:{seconds:00}";
		}
	}
}
