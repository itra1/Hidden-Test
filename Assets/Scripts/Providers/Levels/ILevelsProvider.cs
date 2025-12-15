using Assets.Scripts.Providers.Levels.Common;

namespace Assets.Scripts.Providers.Levels {
	public interface ILevelsProvider {
		LevelData GetLevel(int index);
	}
}