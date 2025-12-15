using Assets.Scripts.Providers.Levels.Common;
using UnityEngine.Events;

namespace Assets.Scripts.Game {
	public interface IGameBehaviourEventsHandler {
		UnityEvent<LevelData> OnSetLevelData { get; set; }

		void EmitSetLevelData(LevelData level);
	}
}