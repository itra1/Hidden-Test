using System;
using System.Threading;
using Assets.Scripts.Providers.Levels.Settings;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Game.Handlers.Timers {
	public class GameTimerHandler :IGameTimerHandler, IGameTimerHandlerSet {

		public UnityEvent<bool> OnTimerActiveChange { get; set; } = new();
		public UnityEvent<bool> OnTimerVisibleChange { get; set; } = new();
		public UnityEvent<int> OnTimerUpdate { get; set; } = new();

		private bool _isActive;
		private bool _isVisible;
		private int _timerValue;
		private TimerData _data;
		private CancellationTokenSource _timerCTS;

		public bool IsActive {
			get => _isActive; private set {
				if (_isActive == value)
					return;
				_isActive = value;
				OnTimerActiveChange?.Invoke(_isActive);
			}
		}
		public bool IsVisible {
			get => _isVisible; private set {

				if (_isVisible == value)
					return;
				_isVisible = value;
				OnTimerVisibleChange?.Invoke(_isVisible);
			}
		}

		public int TimerValue => _timerValue;

		public void SetTimer(TimerData data, UnityAction onTimerComplete) {
			_data = data;

			if (!_data.IsEnable) {
				StopTimer();
				IsVisible = false;
				return;
			}
			IsVisible = true;
			_ = StartTimer(_data.Value, onTimerComplete);
		}

		private async UniTask StartTimer(int value, UnityAction onTimerComplete) {
			CancelProcess();
			_timerCTS = new();
			IsActive = true;

			try {
				_timerValue = value;
				OnTimerUpdate?.Invoke(_timerValue);

				while (_timerValue > 0) {
					await UniTask.Delay(1000, cancellationToken: _timerCTS.Token);
					_timerValue -= 1;
					OnTimerUpdate?.Invoke(_timerValue);
				}

				onTimerComplete?.Invoke();

			} catch (OperationCanceledException) {

			} catch {

			}
		}

		public void StopTimer() {
			CancelProcess();
		}

		private void CancelProcess() {
			if (_timerCTS != null) {
				if (!_timerCTS.IsCancellationRequested)
					_timerCTS.Cancel();
			}
			_timerCTS = null;
		}

	}
}
