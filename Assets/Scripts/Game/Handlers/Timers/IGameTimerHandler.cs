using UnityEngine.Events;

namespace Assets.Scripts.Game.Handlers.Timers {
	public interface IGameTimerHandler {

		UnityEvent<bool> OnTimerActiveChange { get; set; }
		UnityEvent<bool> OnTimerVisibleChange { get; set; }
		UnityEvent<int> OnTimerUpdate { get; set; }
		bool IsActive { get; }
		bool IsVisible { get; }
		int TimerValue { get; }
	}
}