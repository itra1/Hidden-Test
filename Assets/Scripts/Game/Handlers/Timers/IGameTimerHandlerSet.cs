using Assets.Scripts.Providers.Levels.Settings;
using UnityEngine.Events;

namespace Assets.Scripts.Game.Handlers.Timers {
	public interface IGameTimerHandlerSet {

		void SetTimer(TimerData data, UnityAction onTimerComplete);
		void StopTimer();
	}
}