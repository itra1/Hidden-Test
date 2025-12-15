using Assets.Scripts.Providers.Levels.Common;
using UnityEngine.Events;

namespace Assets.Scripts.Game {
	public class GameBehaviourEventsHandler :IGameBehaviourEventsHandler {

		public UnityEvent<LevelData> OnSetLevelData { get; set; } = new();

		public void EmitSetLevelData(LevelData level) {
			OnSetLevelData?.Invoke(level);
		}
	}
}
